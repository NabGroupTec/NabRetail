<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mobile_ShowFactor
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.cln_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_KolCount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_JozCount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Vahed = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Fe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Darsad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_DarsadMon = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Anbar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_Money = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Disc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label6 = New System.Windows.Forms.Label
        Me.Txtallmoney = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtMonFac = New System.Windows.Forms.TextBox
        Me.LFactor = New System.Windows.Forms.Label
        Me.LState = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolFrosh = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.TxtIdPeople = New System.Windows.Forms.Label
        Me.TxtCity = New System.Windows.Forms.Label
        Me.TxtIdCityFac = New System.Windows.Forms.Label
        Me.BtnShowfactor = New System.Windows.Forms.Button
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.LIdName = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.DGV1)
        Me.GroupBox3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(925, 522)
        Me.GroupBox3.TabIndex = 49
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
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cln_type, Me.cln_name, Me.Cln_KolCount, Me.Cln_JozCount, Me.Cln_Vahed, Me.Cln_Fe, Me.Cln_Darsad, Me.Cln_DarsadMon, Me.Cln_Anbar, Me.cln_Money, Me.Cln_Disc, Me.Cln_Code})
        Me.DGV1.Location = New System.Drawing.Point(10, 22)
        Me.DGV1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV1.Size = New System.Drawing.Size(909, 490)
        Me.DGV1.TabIndex = 7
        '
        'cln_type
        '
        Me.cln_type.DataPropertyName = "GroupKala"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.cln_type.DefaultCellStyle = DataGridViewCellStyle2
        Me.cln_type.HeaderText = "گروه کالا"
        Me.cln_type.Name = "cln_type"
        Me.cln_type.ReadOnly = True
        Me.cln_type.Width = 120
        '
        'cln_name
        '
        Me.cln_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.cln_name.DataPropertyName = "NamKala"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cln_name.DefaultCellStyle = DataGridViewCellStyle3
        Me.cln_name.HeaderText = "نام كالا"
        Me.cln_name.MaxInputLength = 200
        Me.cln_name.Name = "cln_name"
        Me.cln_name.ReadOnly = True
        Me.cln_name.Width = 136
        '
        'Cln_KolCount
        '
        Me.Cln_KolCount.DataPropertyName = "KolCount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_KolCount.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_KolCount.HeaderText = "تعداد"
        Me.Cln_KolCount.MaxInputLength = 10
        Me.Cln_KolCount.Name = "Cln_KolCount"
        Me.Cln_KolCount.ReadOnly = True
        Me.Cln_KolCount.Width = 60
        '
        'Cln_JozCount
        '
        Me.Cln_JozCount.DataPropertyName = "JozCount"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_JozCount.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_JozCount.HeaderText = "نسبت جزء"
        Me.Cln_JozCount.MaxInputLength = 10
        Me.Cln_JozCount.Name = "Cln_JozCount"
        Me.Cln_JozCount.ReadOnly = True
        Me.Cln_JozCount.Width = 70
        '
        'Cln_Vahed
        '
        Me.Cln_Vahed.DataPropertyName = "Vahed"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        Me.Cln_Vahed.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_Vahed.HeaderText = "واحد"
        Me.Cln_Vahed.Name = "Cln_Vahed"
        Me.Cln_Vahed.ReadOnly = True
        Me.Cln_Vahed.Width = 50
        '
        'Cln_Fe
        '
        Me.Cln_Fe.DataPropertyName = "Fe"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Cln_Fe.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_Fe.HeaderText = "فی"
        Me.Cln_Fe.MaxInputLength = 10
        Me.Cln_Fe.Name = "Cln_Fe"
        Me.Cln_Fe.ReadOnly = True
        Me.Cln_Fe.Width = 80
        '
        'Cln_Darsad
        '
        Me.Cln_Darsad.DataPropertyName = "DarsadDiscount"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Darsad.DefaultCellStyle = DataGridViewCellStyle8
        Me.Cln_Darsad.HeaderText = "درصد تخفیف"
        Me.Cln_Darsad.MaxInputLength = 5
        Me.Cln_Darsad.Name = "Cln_Darsad"
        Me.Cln_Darsad.ReadOnly = True
        Me.Cln_Darsad.Width = 40
        '
        'Cln_DarsadMon
        '
        Me.Cln_DarsadMon.DataPropertyName = "DarsadMon"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.Cln_DarsadMon.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cln_DarsadMon.HeaderText = "مبلغ تخفیف"
        Me.Cln_DarsadMon.Name = "Cln_DarsadMon"
        Me.Cln_DarsadMon.ReadOnly = True
        Me.Cln_DarsadMon.Width = 50
        '
        'Cln_Anbar
        '
        Me.Cln_Anbar.DataPropertyName = "NamAnbar"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Anbar.DefaultCellStyle = DataGridViewCellStyle10
        Me.Cln_Anbar.HeaderText = "انبار"
        Me.Cln_Anbar.MaxInputLength = 200
        Me.Cln_Anbar.Name = "Cln_Anbar"
        Me.Cln_Anbar.ReadOnly = True
        Me.Cln_Anbar.Width = 70
        '
        'cln_Money
        '
        Me.cln_Money.DataPropertyName = "Mon"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.cln_Money.DefaultCellStyle = DataGridViewCellStyle11
        Me.cln_Money.HeaderText = "جمع  مبلغ"
        Me.cln_Money.Name = "cln_Money"
        Me.cln_Money.ReadOnly = True
        Me.cln_Money.Width = 90
        '
        'Cln_Disc
        '
        Me.Cln_Disc.DataPropertyName = "KalaDisc"
        Me.Cln_Disc.HeaderText = "توضیحات"
        Me.Cln_Disc.MaxInputLength = 200
        Me.Cln_Disc.Name = "Cln_Disc"
        Me.Cln_Disc.ReadOnly = True
        '
        'Cln_Code
        '
        Me.Cln_Code.DataPropertyName = "IdKala"
        Me.Cln_Code.HeaderText = "CodeKala"
        Me.Cln_Code.Name = "Cln_Code"
        Me.Cln_Code.ReadOnly = True
        Me.Cln_Code.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(236, 541)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 21)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "جمع‌ كل فاکتور"
        '
        'Txtallmoney
        '
        Me.Txtallmoney.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Txtallmoney.BackColor = System.Drawing.Color.White
        Me.Txtallmoney.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Txtallmoney.Location = New System.Drawing.Point(22, 539)
        Me.Txtallmoney.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Txtallmoney.Name = "Txtallmoney"
        Me.Txtallmoney.ReadOnly = True
        Me.Txtallmoney.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Txtallmoney.Size = New System.Drawing.Size(208, 29)
        Me.Txtallmoney.TabIndex = 53
        Me.Txtallmoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.Location = New System.Drawing.Point(454, 541)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 21)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "جمع‌ كل تخفیفات"
        '
        'TxtMonFac
        '
        Me.TxtMonFac.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtMonFac.BackColor = System.Drawing.Color.White
        Me.TxtMonFac.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtMonFac.Location = New System.Drawing.Point(321, 539)
        Me.TxtMonFac.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtMonFac.Name = "TxtMonFac"
        Me.TxtMonFac.ReadOnly = True
        Me.TxtMonFac.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtMonFac.Size = New System.Drawing.Size(127, 29)
        Me.TxtMonFac.TabIndex = 55
        Me.TxtMonFac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LFactor
        '
        Me.LFactor.AutoSize = True
        Me.LFactor.Location = New System.Drawing.Point(6, 101)
        Me.LFactor.Name = "LFactor"
        Me.LFactor.Size = New System.Drawing.Size(0, 21)
        Me.LFactor.TabIndex = 57
        Me.LFactor.Visible = False
        '
        'LState
        '
        Me.LState.AutoSize = True
        Me.LState.Location = New System.Drawing.Point(6, 122)
        Me.LState.Name = "LState"
        Me.LState.Size = New System.Drawing.Size(0, 21)
        Me.LState.TabIndex = 58
        Me.LState.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolFrosh, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 571)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(949, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 59
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolFrosh
        '
        Me.ToolFrosh.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolFrosh.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolFrosh.Name = "ToolFrosh"
        Me.ToolFrosh.Size = New System.Drawing.Size(116, 24)
        Me.ToolFrosh.Text = "F2 نمایش فاکتور فروش"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(80, 24)
        Me.ToolStripStatusLabel2.Text = "F6 وضعیت مالی"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'TxtIdPeople
        '
        Me.TxtIdPeople.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtIdPeople.AutoSize = True
        Me.TxtIdPeople.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtIdPeople.Location = New System.Drawing.Point(568, 541)
        Me.TxtIdPeople.Name = "TxtIdPeople"
        Me.TxtIdPeople.Size = New System.Drawing.Size(0, 21)
        Me.TxtIdPeople.TabIndex = 60
        Me.TxtIdPeople.Visible = False
        '
        'TxtCity
        '
        Me.TxtCity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtCity.AutoSize = True
        Me.TxtCity.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtCity.Location = New System.Drawing.Point(568, 541)
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(0, 21)
        Me.TxtCity.TabIndex = 61
        Me.TxtCity.Visible = False
        '
        'TxtIdCityFac
        '
        Me.TxtIdCityFac.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtIdCityFac.AutoSize = True
        Me.TxtIdCityFac.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtIdCityFac.Location = New System.Drawing.Point(568, 541)
        Me.TxtIdCityFac.Name = "TxtIdCityFac"
        Me.TxtIdCityFac.Size = New System.Drawing.Size(0, 21)
        Me.TxtIdCityFac.TabIndex = 62
        Me.TxtIdCityFac.Visible = False
        '
        'BtnShowfactor
        '
        Me.BtnShowfactor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnShowfactor.Location = New System.Drawing.Point(725, 535)
        Me.BtnShowfactor.Name = "BtnShowfactor"
        Me.BtnShowfactor.Size = New System.Drawing.Size(212, 32)
        Me.BtnShowfactor.TabIndex = 63
        Me.BtnShowfactor.Text = "نمایش فاکتور فروش"
        Me.BtnShowfactor.UseVisualStyleBackColor = True
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel3.Text = "F5 بازخوانی"
        '
        'LIdName
        '
        Me.LIdName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LIdName.AutoSize = True
        Me.LIdName.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LIdName.Location = New System.Drawing.Point(559, 541)
        Me.LIdName.Name = "LIdName"
        Me.LIdName.Size = New System.Drawing.Size(0, 21)
        Me.LIdName.TabIndex = 64
        Me.LIdName.Visible = False
        '
        'Mobile_ShowFactor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 600)
        Me.Controls.Add(Me.LIdName)
        Me.Controls.Add(Me.BtnShowfactor)
        Me.Controls.Add(Me.TxtIdCityFac)
        Me.Controls.Add(Me.TxtCity)
        Me.Controls.Add(Me.TxtIdPeople)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.LState)
        Me.Controls.Add(Me.LFactor)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtMonFac)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Txtallmoney)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "Mobile_ShowFactor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نمایش ریز فاکتور"
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txtallmoney As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtMonFac As System.Windows.Forms.TextBox
    Friend WithEvents LFactor As System.Windows.Forms.Label
    Friend WithEvents LState As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TxtIdPeople As System.Windows.Forms.Label
    Friend WithEvents TxtCity As System.Windows.Forms.Label
    Friend WithEvents TxtIdCityFac As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnShowfactor As System.Windows.Forms.Button
    Friend WithEvents ToolFrosh As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cln_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_KolCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_JozCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Vahed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Fe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Darsad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_DarsadMon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Anbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_Money As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Disc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LIdName As System.Windows.Forms.Label
End Class
