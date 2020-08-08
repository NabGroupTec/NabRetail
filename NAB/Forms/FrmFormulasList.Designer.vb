<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFormulasList
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFormulasList))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Cln_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_FormulName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.cmddel = New System.Windows.Forms.Button()
        Me.cmdadd = New System.Windows.Forms.Button()
        Me.BN = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DGV2 = New System.Windows.Forms.DataGridView()
        Me.cln_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_KolCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_JozCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Fe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Darsad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Anbar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Disc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox8.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BN.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.Controls.Add(Me.DGV)
        Me.GroupBox8.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(705, 40)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox8.Size = New System.Drawing.Size(245, 435)
        Me.GroupBox8.TabIndex = 28
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "لیست فرمول"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
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
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Date, Me.Cln_FormulName, Me.Cln_Id})
        Me.DGV.Location = New System.Drawing.Point(9, 28)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(228, 399)
        Me.DGV.TabIndex = 27
        '
        'Cln_Date
        '
        Me.Cln_Date.DataPropertyName = "D_Date"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Date.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_Date.HeaderText = "تاریخ"
        Me.Cln_Date.Name = "Cln_Date"
        Me.Cln_Date.ReadOnly = True
        Me.Cln_Date.Width = 80
        '
        'Cln_FormulName
        '
        Me.Cln_FormulName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_FormulName.DataPropertyName = "FormulName"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_FormulName.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_FormulName.HeaderText = "نام فرمول"
        Me.Cln_FormulName.Name = "Cln_FormulName"
        Me.Cln_FormulName.ReadOnly = True
        Me.Cln_FormulName.Width = 105
        '
        'Cln_Id
        '
        Me.Cln_Id.DataPropertyName = "Id"
        Me.Cln_Id.HeaderText = "Id"
        Me.Cln_Id.Name = "Cln_Id"
        Me.Cln_Id.ReadOnly = True
        Me.Cln_Id.Visible = False
        '
        'cmdedit
        '
        Me.cmdedit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdedit.Location = New System.Drawing.Point(746, 9)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(99, 30)
        Me.cmdedit.TabIndex = 26
        Me.cmdedit.Text = "ویرایش"
        Me.cmdedit.UseVisualStyleBackColor = True
        '
        'cmddel
        '
        Me.cmddel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmddel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmddel.Location = New System.Drawing.Point(641, 9)
        Me.cmddel.Name = "cmddel"
        Me.cmddel.Size = New System.Drawing.Size(99, 30)
        Me.cmddel.TabIndex = 25
        Me.cmddel.Text = "حذف"
        Me.cmddel.UseVisualStyleBackColor = True
        '
        'cmdadd
        '
        Me.cmdadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdadd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdadd.Location = New System.Drawing.Point(851, 9)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(99, 30)
        Me.cmdadd.TabIndex = 0
        Me.cmdadd.Text = "جدید"
        Me.cmdadd.UseVisualStyleBackColor = True
        '
        'BN
        '
        Me.BN.AddNewItem = Nothing
        Me.BN.AutoSize = False
        Me.BN.BackColor = System.Drawing.Color.Transparent
        Me.BN.CountItem = Me.BindingNavigatorCountItem
        Me.BN.CountItemFormat = "از {0}"
        Me.BN.DeleteItem = Nothing
        Me.BN.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BN.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BN.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BN.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BN.Location = New System.Drawing.Point(0, 507)
        Me.BN.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BN.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BN.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BN.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BN.Name = "BN"
        Me.BN.PositionItem = Me.BindingNavigatorPositionItem
        Me.BN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BN.Size = New System.Drawing.Size(958, 31)
        Me.BN.TabIndex = 29
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 28)
        Me.BindingNavigatorCountItem.Text = "از {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "تعداد کل فرمول"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 28)
        Me.BindingNavigatorMoveFirstItem.Text = "اولین فرمول"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 28)
        Me.BindingNavigatorMovePreviousItem.Text = "فرمول قبلی"
        Me.BindingNavigatorMovePreviousItem.ToolTipText = "فرمول قبلی"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 31)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "فرمول فعلی"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 28)
        Me.BindingNavigatorMoveNextItem.Text = "فرمول بعدی"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 28)
        Me.BindingNavigatorMoveLastItem.Text = "آخرین فرمول"
        Me.BindingNavigatorMoveLastItem.ToolTipText = "آخرین شهرستان"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DGV2)
        Me.GroupBox1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(687, 435)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "مشخصات فرمول"
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToResizeRows = False
        Me.DGV2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cln_name, Me.Cln_KolCount, Me.Cln_JozCount, Me.Cln_Fe, Me.Cln_Darsad, Me.Cln_Anbar, Me.Cln_Disc})
        Me.DGV2.Location = New System.Drawing.Point(6, 28)
        Me.DGV2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV2.Size = New System.Drawing.Size(675, 399)
        Me.DGV2.TabIndex = 6
        '
        'cln_name
        '
        Me.cln_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.cln_name.DataPropertyName = "namKala"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cln_name.DefaultCellStyle = DataGridViewCellStyle5
        Me.cln_name.HeaderText = "نام كالا"
        Me.cln_name.MaxInputLength = 200
        Me.cln_name.Name = "cln_name"
        Me.cln_name.ReadOnly = True
        Me.cln_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_name.Width = 175
        '
        'Cln_KolCount
        '
        Me.Cln_KolCount.DataPropertyName = "KolCount"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_KolCount.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_KolCount.HeaderText = "تعداد"
        Me.Cln_KolCount.MaxInputLength = 10
        Me.Cln_KolCount.Name = "Cln_KolCount"
        Me.Cln_KolCount.ReadOnly = True
        Me.Cln_KolCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_KolCount.Width = 60
        '
        'Cln_JozCount
        '
        Me.Cln_JozCount.DataPropertyName = "JozCount"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_JozCount.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_JozCount.HeaderText = "نسبت جزء"
        Me.Cln_JozCount.MaxInputLength = 10
        Me.Cln_JozCount.Name = "Cln_JozCount"
        Me.Cln_JozCount.ReadOnly = True
        Me.Cln_JozCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_JozCount.Width = 70
        '
        'Cln_Fe
        '
        Me.Cln_Fe.DataPropertyName = "Kind"
        Me.Cln_Fe.HeaderText = "کاربرد"
        Me.Cln_Fe.Name = "Cln_Fe"
        Me.Cln_Fe.ReadOnly = True
        Me.Cln_Fe.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Fe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Fe.Width = 75
        '
        'Cln_Darsad
        '
        Me.Cln_Darsad.DataPropertyName = "Darsad"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Darsad.DefaultCellStyle = DataGridViewCellStyle8
        Me.Cln_Darsad.HeaderText = "درصد مشارکت"
        Me.Cln_Darsad.MaxInputLength = 5
        Me.Cln_Darsad.Name = "Cln_Darsad"
        Me.Cln_Darsad.ReadOnly = True
        Me.Cln_Darsad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Darsad.Width = 60
        '
        'Cln_Anbar
        '
        Me.Cln_Anbar.DataPropertyName = "NamAnbar"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Anbar.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cln_Anbar.HeaderText = "انبار"
        Me.Cln_Anbar.MaxInputLength = 200
        Me.Cln_Anbar.Name = "Cln_Anbar"
        Me.Cln_Anbar.ReadOnly = True
        Me.Cln_Anbar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Anbar.Width = 70
        '
        'Cln_Disc
        '
        Me.Cln_Disc.DataPropertyName = "KalaDisc"
        Me.Cln_Disc.HeaderText = "توضیحات"
        Me.Cln_Disc.MaxInputLength = 200
        Me.Cln_Disc.Name = "Cln_Disc"
        Me.Cln_Disc.ReadOnly = True
        Me.Cln_Disc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Disc.Width = 125
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 478)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(958, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 31
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(52, 24)
        Me.ToolStripStatusLabel2.Text = "F2 جدید"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel3.Text = "F3 ویرایش"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(55, 24)
        Me.ToolStripStatusLabel4.Text = "F4 حذف "
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel5.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'FrmFormulasList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 538)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmddel)
        Me.Controls.Add(Me.BN)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.cmdadd)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmFormulasList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "فرمول تولید"
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BN.ResumeLayout(False)
        Me.BN.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmddel As System.Windows.Forms.Button
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents BN As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DGV2 As DataGridView
    Friend WithEvents cln_name As DataGridViewTextBoxColumn
    Friend WithEvents Cln_KolCount As DataGridViewTextBoxColumn
    Friend WithEvents Cln_JozCount As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Fe As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Darsad As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Anbar As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Disc As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Date As DataGridViewTextBoxColumn
    Friend WithEvents Cln_FormulName As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Id As DataGridViewTextBoxColumn
End Class
