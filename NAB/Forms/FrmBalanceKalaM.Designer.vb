<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBalanceKalaM
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtnReport = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Cln_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cln_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_KolCount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_JozCount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_tKol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_TJoz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Darsad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_t1Kol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_t1Joz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_t1MKol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_t1MJoz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_OrderKol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_OrderJoz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Fe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_ton = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Mon = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_DK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_Kol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Joz = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_W = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TxtAllMon = New System.Windows.Forms.TextBox
        Me.TxtW = New System.Windows.Forms.TextBox
        Me.TxtOrderKol = New System.Windows.Forms.TextBox
        Me.TxtOrderJoz = New System.Windows.Forms.TextBox
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnReport
        '
        Me.BtnReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReport.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnReport.Location = New System.Drawing.Point(903, 525)
        Me.BtnReport.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnReport.Name = "BtnReport"
        Me.BtnReport.Size = New System.Drawing.Size(111, 30)
        Me.BtnReport.TabIndex = 63
        Me.BtnReport.Text = "چاپ گزارش"
        Me.BtnReport.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 560)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(1018, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 64
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(82, 24)
        Me.ToolStripStatusLabel5.Text = "F2 چاپ گزارش"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Id, Me.cln_name, Me.Cln_KolCount, Me.Cln_JozCount, Me.Cln_tKol, Me.Cln_TJoz, Me.Cln_Darsad, Me.Cln_t1Kol, Me.Cln_t1Joz, Me.Cln_t1MKol, Me.Cln_t1MJoz, Me.Cln_OrderKol, Me.Cln_OrderJoz, Me.Cln_Fe, Me.Cln_ton, Me.Cln_Mon, Me.Cln_DK, Me.Cln_Kol, Me.Cln_Joz, Me.Cln_W})
        Me.DGV1.Location = New System.Drawing.Point(0, 4)
        Me.DGV1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV1.Size = New System.Drawing.Size(1014, 511)
        Me.DGV1.TabIndex = 10
        '
        'Cln_Id
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Id.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_Id.HeaderText = "کد کالا"
        Me.Cln_Id.Name = "Cln_Id"
        Me.Cln_Id.ReadOnly = True
        Me.Cln_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Id.Visible = False
        Me.Cln_Id.Width = 70
        '
        'cln_name
        '
        Me.cln_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cln_name.DefaultCellStyle = DataGridViewCellStyle3
        Me.cln_name.HeaderText = "نام كالا"
        Me.cln_name.MaxInputLength = 200
        Me.cln_name.Name = "cln_name"
        Me.cln_name.ReadOnly = True
        Me.cln_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cln_name.Width = 171
        '
        'Cln_KolCount
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_KolCount.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_KolCount.HeaderText = "موجودی کل"
        Me.Cln_KolCount.MaxInputLength = 10
        Me.Cln_KolCount.Name = "Cln_KolCount"
        Me.Cln_KolCount.ReadOnly = True
        Me.Cln_KolCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_KolCount.Width = 55
        '
        'Cln_JozCount
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_JozCount.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_JozCount.HeaderText = "موجودی جزء"
        Me.Cln_JozCount.MaxInputLength = 10
        Me.Cln_JozCount.Name = "Cln_JozCount"
        Me.Cln_JozCount.ReadOnly = True
        Me.Cln_JozCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_JozCount.Width = 55
        '
        'Cln_tKol
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_tKol.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_tKol.HeaderText = "تردد کل"
        Me.Cln_tKol.Name = "Cln_tKol"
        Me.Cln_tKol.ReadOnly = True
        Me.Cln_tKol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_tKol.Width = 55
        '
        'Cln_TJoz
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_TJoz.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_TJoz.HeaderText = "تردد جزء"
        Me.Cln_TJoz.Name = "Cln_TJoz"
        Me.Cln_TJoz.ReadOnly = True
        Me.Cln_TJoz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_TJoz.Width = 55
        '
        'Cln_Darsad
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Darsad.DefaultCellStyle = DataGridViewCellStyle8
        Me.Cln_Darsad.HeaderText = "درصد تردد"
        Me.Cln_Darsad.Name = "Cln_Darsad"
        Me.Cln_Darsad.ReadOnly = True
        Me.Cln_Darsad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Darsad.Visible = False
        Me.Cln_Darsad.Width = 50
        '
        'Cln_t1Kol
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_t1Kol.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cln_t1Kol.HeaderText = "تردد 1 هفته.کل"
        Me.Cln_t1Kol.Name = "Cln_t1Kol"
        Me.Cln_t1Kol.ReadOnly = True
        Me.Cln_t1Kol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_t1Kol.Width = 60
        '
        'Cln_t1Joz
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_t1Joz.DefaultCellStyle = DataGridViewCellStyle10
        Me.Cln_t1Joz.HeaderText = "تردد 1 هفته.جزء"
        Me.Cln_t1Joz.Name = "Cln_t1Joz"
        Me.Cln_t1Joz.ReadOnly = True
        Me.Cln_t1Joz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_t1Joz.Width = 60
        '
        'Cln_t1MKol
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_t1MKol.DefaultCellStyle = DataGridViewCellStyle11
        Me.Cln_t1MKol.HeaderText = "تردد 1 ماهه.کل"
        Me.Cln_t1MKol.Name = "Cln_t1MKol"
        Me.Cln_t1MKol.ReadOnly = True
        Me.Cln_t1MKol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_t1MKol.Width = 60
        '
        'Cln_t1MJoz
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_t1MJoz.DefaultCellStyle = DataGridViewCellStyle12
        Me.Cln_t1MJoz.HeaderText = "تردد 1 ماهه.جزء"
        Me.Cln_t1MJoz.Name = "Cln_t1MJoz"
        Me.Cln_t1MJoz.ReadOnly = True
        Me.Cln_t1MJoz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_t1MJoz.Width = 60
        '
        'Cln_OrderKol
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cln_OrderKol.DefaultCellStyle = DataGridViewCellStyle13
        Me.Cln_OrderKol.HeaderText = "سفارش  کل"
        Me.Cln_OrderKol.Name = "Cln_OrderKol"
        Me.Cln_OrderKol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_OrderKol.Width = 65
        '
        'Cln_OrderJoz
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cln_OrderJoz.DefaultCellStyle = DataGridViewCellStyle14
        Me.Cln_OrderJoz.HeaderText = "سفارش  جزء"
        Me.Cln_OrderJoz.Name = "Cln_OrderJoz"
        Me.Cln_OrderJoz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_OrderJoz.Width = 65
        '
        'Cln_Fe
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cln_Fe.DefaultCellStyle = DataGridViewCellStyle15
        Me.Cln_Fe.HeaderText = "فی"
        Me.Cln_Fe.Name = "Cln_Fe"
        Me.Cln_Fe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Fe.Width = 50
        '
        'Cln_ton
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_ton.DefaultCellStyle = DataGridViewCellStyle16
        Me.Cln_ton.HeaderText = "تناژ"
        Me.Cln_ton.Name = "Cln_ton"
        Me.Cln_ton.ReadOnly = True
        Me.Cln_ton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_ton.Width = 80
        '
        'Cln_Mon
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Mon.DefaultCellStyle = DataGridViewCellStyle17
        Me.Cln_Mon.HeaderText = "جمع مبلغ"
        Me.Cln_Mon.Name = "Cln_Mon"
        Me.Cln_Mon.ReadOnly = True
        Me.Cln_Mon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Mon.Width = 80
        '
        'Cln_DK
        '
        Me.Cln_DK.HeaderText = "DK"
        Me.Cln_DK.Name = "Cln_DK"
        Me.Cln_DK.ReadOnly = True
        Me.Cln_DK.Visible = False
        '
        'Cln_Kol
        '
        Me.Cln_Kol.HeaderText = "Kol"
        Me.Cln_Kol.Name = "Cln_Kol"
        Me.Cln_Kol.ReadOnly = True
        Me.Cln_Kol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Kol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Kol.Visible = False
        '
        'Cln_Joz
        '
        Me.Cln_Joz.HeaderText = "Joz"
        Me.Cln_Joz.Name = "Cln_Joz"
        Me.Cln_Joz.ReadOnly = True
        Me.Cln_Joz.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Joz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cln_Joz.Visible = False
        '
        'Cln_W
        '
        Me.Cln_W.HeaderText = "weight"
        Me.Cln_W.Name = "Cln_W"
        Me.Cln_W.ReadOnly = True
        Me.Cln_W.Visible = False
        '
        'TxtAllMon
        '
        Me.TxtAllMon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtAllMon.BackColor = System.Drawing.SystemColors.Window
        Me.TxtAllMon.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtAllMon.Location = New System.Drawing.Point(2, 517)
        Me.TxtAllMon.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtAllMon.Name = "TxtAllMon"
        Me.TxtAllMon.ReadOnly = True
        Me.TxtAllMon.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAllMon.Size = New System.Drawing.Size(80, 29)
        Me.TxtAllMon.TabIndex = 65
        Me.TxtAllMon.Text = "0"
        Me.TxtAllMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtW
        '
        Me.TxtW.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtW.BackColor = System.Drawing.SystemColors.Window
        Me.TxtW.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtW.Location = New System.Drawing.Point(82, 517)
        Me.TxtW.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtW.Name = "TxtW"
        Me.TxtW.ReadOnly = True
        Me.TxtW.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtW.Size = New System.Drawing.Size(80, 29)
        Me.TxtW.TabIndex = 66
        Me.TxtW.Text = "0"
        Me.TxtW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtOrderKol
        '
        Me.TxtOrderKol.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtOrderKol.BackColor = System.Drawing.SystemColors.Window
        Me.TxtOrderKol.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtOrderKol.Location = New System.Drawing.Point(276, 517)
        Me.TxtOrderKol.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtOrderKol.Name = "TxtOrderKol"
        Me.TxtOrderKol.ReadOnly = True
        Me.TxtOrderKol.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtOrderKol.Size = New System.Drawing.Size(65, 29)
        Me.TxtOrderKol.TabIndex = 68
        Me.TxtOrderKol.Text = "0"
        Me.TxtOrderKol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtOrderJoz
        '
        Me.TxtOrderJoz.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtOrderJoz.BackColor = System.Drawing.SystemColors.Window
        Me.TxtOrderJoz.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtOrderJoz.Location = New System.Drawing.Point(211, 517)
        Me.TxtOrderJoz.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtOrderJoz.Name = "TxtOrderJoz"
        Me.TxtOrderJoz.ReadOnly = True
        Me.TxtOrderJoz.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtOrderJoz.Size = New System.Drawing.Size(65, 29)
        Me.TxtOrderJoz.TabIndex = 67
        Me.TxtOrderJoz.Text = "0"
        Me.TxtOrderJoz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmBalanceKalaM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 589)
        Me.Controls.Add(Me.TxtOrderKol)
        Me.Controls.Add(Me.TxtOrderJoz)
        Me.Controls.Add(Me.TxtW)
        Me.Controls.Add(Me.TxtAllMon)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.BtnReport)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmBalanceKalaM"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "سفارش خرید دستی"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnReport As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Cln_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cln_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_KolCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_JozCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_tKol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_TJoz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Darsad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_t1Kol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_t1Joz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_t1MKol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_t1MJoz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_OrderKol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_OrderJoz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Fe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_ton As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Mon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_DK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_Kol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Joz As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_W As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtAllMon As System.Windows.Forms.TextBox
    Friend WithEvents TxtW As System.Windows.Forms.TextBox
    Friend WithEvents TxtOrderKol As System.Windows.Forms.TextBox
    Friend WithEvents TxtOrderJoz As System.Windows.Forms.TextBox
End Class
