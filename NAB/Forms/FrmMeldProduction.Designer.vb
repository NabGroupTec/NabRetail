<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeldProduction
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtDate = New FarsiDate.FarsiDate()
        Me.TxtDisc = New System.Windows.Forms.TextBox()
        Me.TxtSanad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtId = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        Me.cln_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cln_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_KolCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_JozCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Vahed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Fe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Darsad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Anbar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Use = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Disc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_CodeAnbar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_DK = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cln_KOL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_JOZ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LEdit = New System.Windows.Forms.Label()
        Me.LIdFac = New System.Windows.Forms.Label()
        Me.LState = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtDate)
        Me.GroupBox2.Controls.Add(Me.TxtDisc)
        Me.GroupBox2.Controls.Add(Me.TxtSanad)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TxtId)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(885, 67)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "مشخصات فرمول"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(846, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 21)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "تاریخ"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(478, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 21)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "توضیحات"
        '
        'TxtDate
        '
        Me.TxtDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtDate.Location = New System.Drawing.Point(740, 22)
        Me.TxtDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDate.Size = New System.Drawing.Size(82, 29)
        Me.TxtDate.TabIndex = 1
        Me.TxtDate.ThisText = Nothing
        '
        'TxtDisc
        '
        Me.TxtDisc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDisc.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDisc.Location = New System.Drawing.Point(6, 22)
        Me.TxtDisc.MaxLength = 200
        Me.TxtDisc.Name = "TxtDisc"
        Me.TxtDisc.ShortcutsEnabled = False
        Me.TxtDisc.Size = New System.Drawing.Size(466, 29)
        Me.TxtDisc.TabIndex = 3
        '
        'TxtSanad
        '
        Me.TxtSanad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSanad.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSanad.Location = New System.Drawing.Point(552, 22)
        Me.TxtSanad.MaxLength = 20
        Me.TxtSanad.Name = "TxtSanad"
        Me.TxtSanad.ShortcutsEnabled = False
        Me.TxtSanad.Size = New System.Drawing.Size(93, 29)
        Me.TxtSanad.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(648, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 21)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "فرمول"
        '
        'TxtId
        '
        Me.TxtId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtId.BackColor = System.Drawing.SystemColors.Window
        Me.TxtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtId.Location = New System.Drawing.Point(563, 22)
        Me.TxtId.MaxLength = 20
        Me.TxtId.Name = "TxtId"
        Me.TxtId.ReadOnly = True
        Me.TxtId.ShortcutsEnabled = False
        Me.TxtId.Size = New System.Drawing.Size(33, 29)
        Me.TxtId.TabIndex = 58
        Me.TxtId.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.DGV1)
        Me.GroupBox3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(885, 374)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "مشخصات کالا"
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
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cln_type, Me.cln_name, Me.Cln_KolCount, Me.Cln_JozCount, Me.Cln_Vahed, Me.Cln_Fe, Me.Cln_Darsad, Me.Cln_Anbar, Me.Cln_Use, Me.Cln_Disc, Me.Cln_Code, Me.Cln_CodeAnbar, Me.Cln_DK, Me.Cln_KOL, Me.Cln_JOZ})
        Me.DGV1.Location = New System.Drawing.Point(10, 22)
        Me.DGV1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV1.Size = New System.Drawing.Size(869, 342)
        Me.DGV1.TabIndex = 5
        '
        'cln_type
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.cln_type.DefaultCellStyle = DataGridViewCellStyle2
        Me.cln_type.HeaderText = "گروه کالا"
        Me.cln_type.Name = "cln_type"
        Me.cln_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_type.Width = 120
        '
        'cln_name
        '
        Me.cln_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.cln_name.DefaultCellStyle = DataGridViewCellStyle3
        Me.cln_name.HeaderText = "نام كالا"
        Me.cln_name.MaxInputLength = 200
        Me.cln_name.Name = "cln_name"
        Me.cln_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_name.Width = 175
        '
        'Cln_KolCount
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        Me.Cln_KolCount.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_KolCount.HeaderText = "تعداد"
        Me.Cln_KolCount.MaxInputLength = 10
        Me.Cln_KolCount.Name = "Cln_KolCount"
        Me.Cln_KolCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_KolCount.Width = 60
        '
        'Cln_JozCount
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.Cln_JozCount.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_JozCount.HeaderText = "نسبت جزء"
        Me.Cln_JozCount.MaxInputLength = 10
        Me.Cln_JozCount.Name = "Cln_JozCount"
        Me.Cln_JozCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_JozCount.Width = 70
        '
        'Cln_Vahed
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        Me.Cln_Vahed.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_Vahed.HeaderText = "واحد"
        Me.Cln_Vahed.Name = "Cln_Vahed"
        Me.Cln_Vahed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Vahed.Width = 50
        '
        'Cln_Fe
        '
        Me.Cln_Fe.HeaderText = "کاربرد"
        Me.Cln_Fe.Name = "Cln_Fe"
        Me.Cln_Fe.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Fe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Fe.Width = 80
        '
        'Cln_Darsad
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.Cln_Darsad.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_Darsad.HeaderText = "درصد مشارکت"
        Me.Cln_Darsad.MaxInputLength = 5
        Me.Cln_Darsad.Name = "Cln_Darsad"
        Me.Cln_Darsad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Darsad.Width = 60
        '
        'Cln_Anbar
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        Me.Cln_Anbar.DefaultCellStyle = DataGridViewCellStyle8
        Me.Cln_Anbar.HeaderText = "انبار"
        Me.Cln_Anbar.MaxInputLength = 200
        Me.Cln_Anbar.Name = "Cln_Anbar"
        Me.Cln_Anbar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Anbar.Width = 70
        '
        'Cln_Use
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Use.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cln_Use.HeaderText = "تولید"
        Me.Cln_Use.MaxInputLength = 30
        Me.Cln_Use.Name = "Cln_Use"
        Me.Cln_Use.Width = 70
        '
        'Cln_Disc
        '
        Me.Cln_Disc.HeaderText = "توضیحات"
        Me.Cln_Disc.MaxInputLength = 200
        Me.Cln_Disc.Name = "Cln_Disc"
        Me.Cln_Disc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Disc.Visible = False
        Me.Cln_Disc.Width = 130
        '
        'Cln_Code
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle10.NullValue = Nothing
        Me.Cln_Code.DefaultCellStyle = DataGridViewCellStyle10
        Me.Cln_Code.HeaderText = "کد کالا"
        Me.Cln_Code.Name = "Cln_Code"
        Me.Cln_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Code.Visible = False
        '
        'Cln_CodeAnbar
        '
        Me.Cln_CodeAnbar.HeaderText = "کد انبار"
        Me.Cln_CodeAnbar.Name = "Cln_CodeAnbar"
        Me.Cln_CodeAnbar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_CodeAnbar.Visible = False
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
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.Location = New System.Drawing.Point(798, 460)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(99, 30)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "ثبت"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 495)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(909, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 52
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
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(78, 24)
        Me.ToolStripStatusLabel7.Text = "Delete حذف "
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'LEdit
        '
        Me.LEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEdit.AutoSize = True
        Me.LEdit.Location = New System.Drawing.Point(902, 96)
        Me.LEdit.Name = "LEdit"
        Me.LEdit.Size = New System.Drawing.Size(0, 21)
        Me.LEdit.TabIndex = 52
        Me.LEdit.Visible = False
        '
        'LIdFac
        '
        Me.LIdFac.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LIdFac.AutoSize = True
        Me.LIdFac.Location = New System.Drawing.Point(917, 96)
        Me.LIdFac.Name = "LIdFac"
        Me.LIdFac.Size = New System.Drawing.Size(0, 21)
        Me.LIdFac.TabIndex = 52
        Me.LIdFac.Visible = False
        '
        'LState
        '
        Me.LState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LState.AutoSize = True
        Me.LState.Location = New System.Drawing.Point(914, 96)
        Me.LState.Name = "LState"
        Me.LState.Size = New System.Drawing.Size(0, 21)
        Me.LState.TabIndex = 52
        Me.LState.Visible = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancel.Location = New System.Drawing.Point(693, 460)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(99, 30)
        Me.BtnCancel.TabIndex = 54
        Me.BtnCancel.Text = "انصراف"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'FrmMeldProduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 524)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.LState)
        Me.Controls.Add(Me.LIdFac)
        Me.Controls.Add(Me.LEdit)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmMeldProduction"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اجرای تولید"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDate As FarsiDate.FarsiDate
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSanad As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtDisc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LEdit As System.Windows.Forms.Label
    Friend WithEvents LIdFac As System.Windows.Forms.Label
    Friend WithEvents LState As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TxtId As TextBox
    Friend WithEvents BtnCancel As Button
    Friend WithEvents cln_type As DataGridViewTextBoxColumn
    Friend WithEvents cln_name As DataGridViewTextBoxColumn
    Friend WithEvents Cln_KolCount As DataGridViewTextBoxColumn
    Friend WithEvents Cln_JozCount As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Vahed As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Fe As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Darsad As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Anbar As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Use As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Disc As DataGridViewTextBoxColumn
    Friend WithEvents Cln_Code As DataGridViewTextBoxColumn
    Friend WithEvents Cln_CodeAnbar As DataGridViewTextBoxColumn
    Friend WithEvents Cln_DK As DataGridViewCheckBoxColumn
    Friend WithEvents Cln_KOL As DataGridViewTextBoxColumn
    Friend WithEvents Cln_JOZ As DataGridViewTextBoxColumn
End Class
