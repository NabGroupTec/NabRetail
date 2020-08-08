<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class People_List
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
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle56 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtnOk = New System.Windows.Forms.Button
        Me.TxtSearch = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Cln_Nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Ostan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_City = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdOstan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdCity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_Tell1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Tell2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Address = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Namfac = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_NamCo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Idpart = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnExit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RdoAll = New System.Windows.Forms.RadioButton
        Me.RdoAval = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CmbGroup = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.RdoGroup = New System.Windows.Forms.RadioButton
        Me.RdoMCode = New System.Windows.Forms.RadioButton
        Me.RdoAddress = New System.Windows.Forms.RadioButton
        Me.RdoNamfac = New System.Windows.Forms.RadioButton
        Me.RdoTell2 = New System.Windows.Forms.RadioButton
        Me.RdoTell1 = New System.Windows.Forms.RadioButton
        Me.RdoCode = New System.Windows.Forms.RadioButton
        Me.RdoTwo = New System.Windows.Forms.RadioButton
        Me.RdoOne = New System.Windows.Forms.RadioButton
        Me.RdoAllKala = New System.Windows.Forms.RadioButton
        Me.ChkAll = New System.Windows.Forms.CheckBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnNewP = New System.Windows.Forms.Button
        Me.ChkP = New System.Windows.Forms.CheckBox
        Me.CmbPart = New System.Windows.Forms.ComboBox
        Me.CmbCity = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbOstan = New System.Windows.Forms.ComboBox
        Me.TxtOstan = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(631, 601)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(88, 30)
        Me.BtnOk.TabIndex = 0
        Me.BtnOk.Text = "انتخاب"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'TxtSearch
        '
        Me.TxtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSearch.Location = New System.Drawing.Point(15, 135)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtSearch.Size = New System.Drawing.Size(637, 29)
        Me.TxtSearch.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(658, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "جستجو"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle50.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle50
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Nam, Me.Cln_IdP, Me.Cln_Code, Me.Cln_Ostan, Me.Cln_City, Me.Cln_IdOstan, Me.Cln_IdCity, Me.Cln_Select, Me.Cln_Tell1, Me.Cln_Tell2, Me.Cln_Address, Me.Cln_Namfac, Me.Cln_NamCo, Me.Cln_IdGroup, Me.Cln_Idpart})
        Me.DGV.Location = New System.Drawing.Point(12, 180)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(707, 416)
        Me.DGV.TabIndex = 3
        '
        'Cln_Nam
        '
        Me.Cln_Nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Nam.DataPropertyName = "Nam"
        DataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Nam.DefaultCellStyle = DataGridViewCellStyle51
        Me.Cln_Nam.HeaderText = "نام طرف حساب"
        Me.Cln_Nam.Name = "Cln_Nam"
        Me.Cln_Nam.ReadOnly = True
        Me.Cln_Nam.Width = 162
        '
        'Cln_IdP
        '
        Me.Cln_IdP.DataPropertyName = "Id"
        DataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_IdP.DefaultCellStyle = DataGridViewCellStyle52
        Me.Cln_IdP.HeaderText = "کد"
        Me.Cln_IdP.Name = "Cln_IdP"
        Me.Cln_IdP.ReadOnly = True
        Me.Cln_IdP.Width = 50
        '
        'Cln_Code
        '
        Me.Cln_Code.DataPropertyName = "MCode"
        DataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Code.DefaultCellStyle = DataGridViewCellStyle53
        Me.Cln_Code.HeaderText = "کد دستی"
        Me.Cln_Code.Name = "Cln_Code"
        Me.Cln_Code.ReadOnly = True
        Me.Cln_Code.Width = 80
        '
        'Cln_Ostan
        '
        Me.Cln_Ostan.DataPropertyName = "NamO"
        DataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle54.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Cln_Ostan.DefaultCellStyle = DataGridViewCellStyle54
        Me.Cln_Ostan.HeaderText = "استان"
        Me.Cln_Ostan.Name = "Cln_Ostan"
        Me.Cln_Ostan.ReadOnly = True
        '
        'Cln_City
        '
        Me.Cln_City.DataPropertyName = "NamCI"
        DataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle55.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Cln_City.DefaultCellStyle = DataGridViewCellStyle55
        Me.Cln_City.HeaderText = "شهرستان"
        Me.Cln_City.Name = "Cln_City"
        Me.Cln_City.ReadOnly = True
        Me.Cln_City.Width = 80
        '
        'Cln_IdOstan
        '
        Me.Cln_IdOstan.DataPropertyName = "IdOstan"
        Me.Cln_IdOstan.HeaderText = "IdOstan"
        Me.Cln_IdOstan.Name = "Cln_IdOstan"
        Me.Cln_IdOstan.Visible = False
        '
        'Cln_IdCity
        '
        Me.Cln_IdCity.DataPropertyName = "IdCity"
        Me.Cln_IdCity.HeaderText = "IdCity"
        Me.Cln_IdCity.Name = "Cln_IdCity"
        Me.Cln_IdCity.Visible = False
        '
        'Cln_Select
        '
        Me.Cln_Select.HeaderText = "انتخاب"
        Me.Cln_Select.Name = "Cln_Select"
        Me.Cln_Select.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_Select.Visible = False
        Me.Cln_Select.Width = 50
        '
        'Cln_Tell1
        '
        Me.Cln_Tell1.DataPropertyName = "Tell1"
        Me.Cln_Tell1.HeaderText = "تلفن1"
        Me.Cln_Tell1.Name = "Cln_Tell1"
        Me.Cln_Tell1.Visible = False
        '
        'Cln_Tell2
        '
        Me.Cln_Tell2.DataPropertyName = "Tell2"
        Me.Cln_Tell2.HeaderText = "تلفن2"
        Me.Cln_Tell2.Name = "Cln_Tell2"
        Me.Cln_Tell2.Visible = False
        '
        'Cln_Address
        '
        Me.Cln_Address.DataPropertyName = "Address"
        DataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Address.DefaultCellStyle = DataGridViewCellStyle56
        Me.Cln_Address.HeaderText = "آدرس"
        Me.Cln_Address.Name = "Cln_Address"
        Me.Cln_Address.Width = 192
        '
        'Cln_Namfac
        '
        Me.Cln_Namfac.DataPropertyName = "NamFac"
        Me.Cln_Namfac.HeaderText = "نام فاکتوری"
        Me.Cln_Namfac.Name = "Cln_Namfac"
        Me.Cln_Namfac.Visible = False
        '
        'Cln_NamCo
        '
        Me.Cln_NamCo.DataPropertyName = "NamCo"
        Me.Cln_NamCo.HeaderText = "نام شرکت"
        Me.Cln_NamCo.Name = "Cln_NamCo"
        Me.Cln_NamCo.Visible = False
        '
        'Cln_IdGroup
        '
        Me.Cln_IdGroup.DataPropertyName = "IdGroup"
        Me.Cln_IdGroup.HeaderText = "IdGroup"
        Me.Cln_IdGroup.Name = "Cln_IdGroup"
        Me.Cln_IdGroup.Visible = False
        '
        'Cln_Idpart
        '
        Me.Cln_Idpart.DataPropertyName = "IdPart"
        Me.Cln_Idpart.HeaderText = "IdPart"
        Me.Cln_Idpart.Name = "Cln_Idpart"
        Me.Cln_Idpart.Visible = False
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.Location = New System.Drawing.Point(443, 601)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(88, 30)
        Me.BtnExit.TabIndex = 4
        Me.BtnExit.Text = "انصراف"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.RdoAll)
        Me.GroupBox1.Controls.Add(Me.RdoAval)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(196, 70)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "جستجو از"
        '
        'RdoAll
        '
        Me.RdoAll.AutoSize = True
        Me.RdoAll.Location = New System.Drawing.Point(6, 27)
        Me.RdoAll.Name = "RdoAll"
        Me.RdoAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoAll.Size = New System.Drawing.Size(64, 25)
        Me.RdoAll.TabIndex = 43
        Me.RdoAll.Text = "کل متن"
        Me.RdoAll.UseVisualStyleBackColor = True
        '
        'RdoAval
        '
        Me.RdoAval.AutoSize = True
        Me.RdoAval.Location = New System.Drawing.Point(119, 27)
        Me.RdoAval.Name = "RdoAval"
        Me.RdoAval.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoAval.Size = New System.Drawing.Size(64, 25)
        Me.RdoAval.TabIndex = 42
        Me.RdoAval.Text = "اول متن"
        Me.RdoAval.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ChkP)
        Me.GroupBox2.Controls.Add(Me.CmbGroup)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.RdoGroup)
        Me.GroupBox2.Controls.Add(Me.CmbPart)
        Me.GroupBox2.Controls.Add(Me.RdoMCode)
        Me.GroupBox2.Controls.Add(Me.CmbCity)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.RdoAddress)
        Me.GroupBox2.Controls.Add(Me.CmbOstan)
        Me.GroupBox2.Controls.Add(Me.RdoNamfac)
        Me.GroupBox2.Controls.Add(Me.TxtOstan)
        Me.GroupBox2.Controls.Add(Me.RdoTell2)
        Me.GroupBox2.Controls.Add(Me.RdoTell1)
        Me.GroupBox2.Controls.Add(Me.RdoCode)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TxtSearch)
        Me.GroupBox2.Controls.Add(Me.RdoTwo)
        Me.GroupBox2.Controls.Add(Me.RdoOne)
        Me.GroupBox2.Controls.Add(Me.RdoAllKala)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(707, 169)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "فیلتر اطلاعات"
        '
        'CmbGroup
        '
        Me.CmbGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGroup.Enabled = False
        Me.CmbGroup.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbGroup.FormattingEnabled = True
        Me.CmbGroup.Location = New System.Drawing.Point(222, 74)
        Me.CmbGroup.MaxDropDownItems = 10
        Me.CmbGroup.Name = "CmbGroup"
        Me.CmbGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbGroup.Size = New System.Drawing.Size(138, 29)
        Me.CmbGroup.TabIndex = 52
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(366, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 21)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "گروه ویژه"
        '
        'RdoGroup
        '
        Me.RdoGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoGroup.AutoSize = True
        Me.RdoGroup.Location = New System.Drawing.Point(30, 49)
        Me.RdoGroup.Name = "RdoGroup"
        Me.RdoGroup.Size = New System.Drawing.Size(75, 25)
        Me.RdoGroup.TabIndex = 51
        Me.RdoGroup.Text = "گروه ویژه"
        Me.RdoGroup.UseVisualStyleBackColor = True
        '
        'RdoMCode
        '
        Me.RdoMCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoMCode.AutoSize = True
        Me.RdoMCode.Location = New System.Drawing.Point(32, 18)
        Me.RdoMCode.Name = "RdoMCode"
        Me.RdoMCode.Size = New System.Drawing.Size(73, 25)
        Me.RdoMCode.TabIndex = 50
        Me.RdoMCode.Text = "کد دستی"
        Me.RdoMCode.UseVisualStyleBackColor = True
        '
        'RdoAddress
        '
        Me.RdoAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoAddress.AutoSize = True
        Me.RdoAddress.Location = New System.Drawing.Point(184, 45)
        Me.RdoAddress.Name = "RdoAddress"
        Me.RdoAddress.Size = New System.Drawing.Size(60, 25)
        Me.RdoAddress.TabIndex = 41
        Me.RdoAddress.Text = "آدرس"
        Me.RdoAddress.UseVisualStyleBackColor = True
        '
        'RdoNamfac
        '
        Me.RdoNamfac.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoNamfac.AutoSize = True
        Me.RdoNamfac.Location = New System.Drawing.Point(166, 18)
        Me.RdoNamfac.Name = "RdoNamfac"
        Me.RdoNamfac.Size = New System.Drawing.Size(78, 25)
        Me.RdoNamfac.TabIndex = 40
        Me.RdoNamfac.Text = "نام شرکت"
        Me.RdoNamfac.UseVisualStyleBackColor = True
        '
        'RdoTell2
        '
        Me.RdoTell2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoTell2.AutoSize = True
        Me.RdoTell2.Location = New System.Drawing.Point(322, 45)
        Me.RdoTell2.Name = "RdoTell2"
        Me.RdoTell2.Size = New System.Drawing.Size(80, 25)
        Me.RdoTell2.TabIndex = 39
        Me.RdoTell2.Text = "تلفن همراه"
        Me.RdoTell2.UseVisualStyleBackColor = True
        '
        'RdoTell1
        '
        Me.RdoTell1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoTell1.AutoSize = True
        Me.RdoTell1.Location = New System.Drawing.Point(326, 18)
        Me.RdoTell1.Name = "RdoTell1"
        Me.RdoTell1.Size = New System.Drawing.Size(76, 25)
        Me.RdoTell1.TabIndex = 38
        Me.RdoTell1.Text = "تلفن ثابت"
        Me.RdoTell1.UseVisualStyleBackColor = True
        '
        'RdoCode
        '
        Me.RdoCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoCode.AutoSize = True
        Me.RdoCode.Location = New System.Drawing.Point(653, 45)
        Me.RdoCode.Name = "RdoCode"
        Me.RdoCode.Size = New System.Drawing.Size(42, 25)
        Me.RdoCode.TabIndex = 35
        Me.RdoCode.Text = "کد"
        Me.RdoCode.UseVisualStyleBackColor = True
        '
        'RdoTwo
        '
        Me.RdoTwo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoTwo.AutoSize = True
        Me.RdoTwo.Location = New System.Drawing.Point(468, 45)
        Me.RdoTwo.Name = "RdoTwo"
        Me.RdoTwo.Size = New System.Drawing.Size(72, 25)
        Me.RdoTwo.TabIndex = 37
        Me.RdoTwo.Text = "شهرستان"
        Me.RdoTwo.UseVisualStyleBackColor = True
        '
        'RdoOne
        '
        Me.RdoOne.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoOne.AutoSize = True
        Me.RdoOne.Location = New System.Drawing.Point(486, 18)
        Me.RdoOne.Name = "RdoOne"
        Me.RdoOne.Size = New System.Drawing.Size(54, 25)
        Me.RdoOne.TabIndex = 36
        Me.RdoOne.Text = "استان"
        Me.RdoOne.UseVisualStyleBackColor = True
        '
        'RdoAllKala
        '
        Me.RdoAllKala.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoAllKala.AutoSize = True
        Me.RdoAllKala.Location = New System.Drawing.Point(584, 18)
        Me.RdoAllKala.Name = "RdoAllKala"
        Me.RdoAllKala.Size = New System.Drawing.Size(111, 25)
        Me.RdoAllKala.TabIndex = 34
        Me.RdoAllKala.Text = "همه طرف حسابها"
        Me.RdoAllKala.UseVisualStyleBackColor = True
        '
        'ChkAll
        '
        Me.ChkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkAll.AutoSize = True
        Me.ChkAll.Location = New System.Drawing.Point(12, 606)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkAll.Size = New System.Drawing.Size(48, 25)
        Me.ChkAll.TabIndex = 35
        Me.ChkAll.Text = "همه"
        Me.ChkAll.UseVisualStyleBackColor = True
        Me.ChkAll.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel7})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 635)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(731, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 37
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(56, 24)
        Me.ToolStripStatusLabel2.Text = "F2 انتخاب"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(108, 24)
        Me.ToolStripStatusLabel4.Text = "F3 طرف حساب جدید"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel3.Text = "F4 انصراف"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel6.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(80, 24)
        Me.ToolStripStatusLabel5.Text = "F6 وضعیت مالی"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel7.Text = "ESC خروج"
        '
        'BtnNewP
        '
        Me.BtnNewP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNewP.Location = New System.Drawing.Point(537, 601)
        Me.BtnNewP.Name = "BtnNewP"
        Me.BtnNewP.Size = New System.Drawing.Size(88, 30)
        Me.BtnNewP.TabIndex = 38
        Me.BtnNewP.Text = "جدید"
        Me.BtnNewP.UseVisualStyleBackColor = True
        '
        'ChkP
        '
        Me.ChkP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkP.AutoSize = True
        Me.ChkP.Enabled = False
        Me.ChkP.Location = New System.Drawing.Point(507, 106)
        Me.ChkP.Name = "ChkP"
        Me.ChkP.Size = New System.Drawing.Size(55, 25)
        Me.ChkP.TabIndex = 31
        Me.ChkP.Text = "مسیر"
        Me.ChkP.UseVisualStyleBackColor = True
        '
        'CmbPart
        '
        Me.CmbPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPart.Enabled = False
        Me.CmbPart.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbPart.FormattingEnabled = True
        Me.CmbPart.Location = New System.Drawing.Point(427, 104)
        Me.CmbPart.Name = "CmbPart"
        Me.CmbPart.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbPart.Size = New System.Drawing.Size(76, 29)
        Me.CmbPart.TabIndex = 32
        '
        'CmbCity
        '
        Me.CmbCity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCity.Enabled = False
        Me.CmbCity.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbCity.FormattingEnabled = True
        Me.CmbCity.Location = New System.Drawing.Point(566, 104)
        Me.CmbCity.Name = "CmbCity"
        Me.CmbCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbCity.Size = New System.Drawing.Size(86, 29)
        Me.CmbCity.TabIndex = 30
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.Location = New System.Drawing.Point(662, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 21)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "استان"
        '
        'CmbOstan
        '
        Me.CmbOstan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbOstan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbOstan.Enabled = False
        Me.CmbOstan.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CmbOstan.FormattingEnabled = True
        Me.CmbOstan.Location = New System.Drawing.Point(427, 74)
        Me.CmbOstan.Name = "CmbOstan"
        Me.CmbOstan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbOstan.Size = New System.Drawing.Size(225, 29)
        Me.CmbOstan.TabIndex = 28
        '
        'TxtOstan
        '
        Me.TxtOstan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOstan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOstan.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtOstan.Location = New System.Drawing.Point(552, 74)
        Me.TxtOstan.MaxLength = 30
        Me.TxtOstan.Name = "TxtOstan"
        Me.TxtOstan.Size = New System.Drawing.Size(50, 29)
        Me.TxtOstan.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(668, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 21)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "شهر"
        '
        'People_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 664)
        Me.Controls.Add(Me.BtnNewP)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ChkAll)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BtnOk)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "People_List"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "لیست انتخاب"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoAll As System.Windows.Forms.RadioButton
    Friend WithEvents RdoAval As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoTwo As System.Windows.Forms.RadioButton
    Friend WithEvents RdoOne As System.Windows.Forms.RadioButton
    Friend WithEvents RdoAllKala As System.Windows.Forms.RadioButton
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnNewP As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RdoCode As System.Windows.Forms.RadioButton
    Friend WithEvents RdoAddress As System.Windows.Forms.RadioButton
    Friend WithEvents RdoNamfac As System.Windows.Forms.RadioButton
    Friend WithEvents RdoTell2 As System.Windows.Forms.RadioButton
    Friend WithEvents RdoTell1 As System.Windows.Forms.RadioButton
    Friend WithEvents RdoMCode As System.Windows.Forms.RadioButton
    Friend WithEvents RdoGroup As System.Windows.Forms.RadioButton
    Friend WithEvents CmbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cln_Nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Ostan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_City As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdOstan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdCity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_Tell1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Tell2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Namfac As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_NamCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Idpart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkP As System.Windows.Forms.CheckBox
    Friend WithEvents CmbPart As System.Windows.Forms.ComboBox
    Friend WithEvents CmbCity As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbOstan As System.Windows.Forms.ComboBox
    Friend WithEvents TxtOstan As System.Windows.Forms.TextBox
End Class
