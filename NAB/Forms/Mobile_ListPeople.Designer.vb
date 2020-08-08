<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mobile_ListPeople
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.BtnOk = New System.Windows.Forms.Button
        Me.BtnDel = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Cln_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Visitor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_User = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Nam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Tell1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Tell2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_time = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_groupnam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_NamO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_NamCI = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_NamP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdOstan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdCity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Idpart = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_IdVisitor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Adres = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.DGV)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(915, 478)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "لیست طرف حساب موقت"
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
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Id, Me.Cln_Visitor, Me.Cln_User, Me.Cln_Nam, Me.Cln_Tell1, Me.Cln_Tell2, Me.Cln_time, Me.Cln_date, Me.Cln_groupnam, Me.Cln_NamO, Me.Cln_NamCI, Me.Cln_NamP, Me.Cln_IdGroup, Me.Cln_IdOstan, Me.Cln_IdCity, Me.Cln_Idpart, Me.Cln_IdVisitor, Me.Cln_Adres})
        Me.DGV.Location = New System.Drawing.Point(6, 28)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.Size = New System.Drawing.Size(903, 444)
        Me.DGV.TabIndex = 0
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(817, 14)
        Me.BtnOk.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(104, 30)
        Me.BtnOk.TabIndex = 75
        Me.BtnOk.Text = "تایید"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnDel.Location = New System.Drawing.Point(707, 14)
        Me.BtnDel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(104, 30)
        Me.BtnDel.TabIndex = 76
        Me.BtnDel.Text = "حذف"
        Me.BtnDel.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 535)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(933, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 77
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(47, 24)
        Me.ToolStripStatusLabel2.Text = "F2 تایید"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(52, 24)
        Me.ToolStripStatusLabel3.Text = "F3 حذف"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'Cln_Id
        '
        Me.Cln_Id.DataPropertyName = "Id"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Id.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_Id.HeaderText = "کد"
        Me.Cln_Id.Name = "Cln_Id"
        Me.Cln_Id.ReadOnly = True
        Me.Cln_Id.Width = 50
        '
        'Cln_Visitor
        '
        Me.Cln_Visitor.DataPropertyName = "IdVisitor"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Visitor.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_Visitor.HeaderText = "ویزیتور"
        Me.Cln_Visitor.Name = "Cln_Visitor"
        Me.Cln_Visitor.ReadOnly = True
        Me.Cln_Visitor.Width = 50
        '
        'Cln_User
        '
        Me.Cln_User.DataPropertyName = "IdUser"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_User.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_User.HeaderText = "کاربر"
        Me.Cln_User.Name = "Cln_User"
        Me.Cln_User.ReadOnly = True
        Me.Cln_User.Width = 50
        '
        'Cln_Nam
        '
        Me.Cln_Nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Nam.DataPropertyName = "Nam"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Nam.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_Nam.HeaderText = "نام"
        Me.Cln_Nam.Name = "Cln_Nam"
        Me.Cln_Nam.ReadOnly = True
        '
        'Cln_Tell1
        '
        Me.Cln_Tell1.DataPropertyName = "Tell1"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cln_Tell1.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cln_Tell1.HeaderText = "تلفن ثابت"
        Me.Cln_Tell1.Name = "Cln_Tell1"
        Me.Cln_Tell1.ReadOnly = True
        Me.Cln_Tell1.Width = 90
        '
        'Cln_Tell2
        '
        Me.Cln_Tell2.DataPropertyName = "Tell2"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cln_Tell2.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cln_Tell2.HeaderText = "موبایل"
        Me.Cln_Tell2.Name = "Cln_Tell2"
        Me.Cln_Tell2.ReadOnly = True
        Me.Cln_Tell2.Width = 90
        '
        'Cln_time
        '
        Me.Cln_time.DataPropertyName = "T_time"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_time.DefaultCellStyle = DataGridViewCellStyle8
        Me.Cln_time.HeaderText = "ساعت"
        Me.Cln_time.Name = "Cln_time"
        Me.Cln_time.ReadOnly = True
        Me.Cln_time.Width = 50
        '
        'Cln_date
        '
        Me.Cln_date.DataPropertyName = "D_date"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_date.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cln_date.HeaderText = "تاریخ"
        Me.Cln_date.Name = "Cln_date"
        Me.Cln_date.ReadOnly = True
        Me.Cln_date.Width = 80
        '
        'Cln_groupnam
        '
        Me.Cln_groupnam.DataPropertyName = "GroupNam"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_groupnam.DefaultCellStyle = DataGridViewCellStyle10
        Me.Cln_groupnam.HeaderText = "گروه"
        Me.Cln_groupnam.Name = "Cln_groupnam"
        Me.Cln_groupnam.ReadOnly = True
        Me.Cln_groupnam.Width = 80
        '
        'Cln_NamO
        '
        Me.Cln_NamO.DataPropertyName = "NamO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_NamO.DefaultCellStyle = DataGridViewCellStyle11
        Me.Cln_NamO.HeaderText = "استان"
        Me.Cln_NamO.Name = "Cln_NamO"
        Me.Cln_NamO.ReadOnly = True
        Me.Cln_NamO.Width = 90
        '
        'Cln_NamCI
        '
        Me.Cln_NamCI.DataPropertyName = "NamCI"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_NamCI.DefaultCellStyle = DataGridViewCellStyle12
        Me.Cln_NamCI.HeaderText = "شهرستان"
        Me.Cln_NamCI.Name = "Cln_NamCI"
        Me.Cln_NamCI.ReadOnly = True
        Me.Cln_NamCI.Width = 70
        '
        'Cln_NamP
        '
        Me.Cln_NamP.DataPropertyName = "NamP"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_NamP.DefaultCellStyle = DataGridViewCellStyle13
        Me.Cln_NamP.HeaderText = "مسیر"
        Me.Cln_NamP.Name = "Cln_NamP"
        Me.Cln_NamP.ReadOnly = True
        Me.Cln_NamP.Width = 60
        '
        'Cln_IdGroup
        '
        Me.Cln_IdGroup.DataPropertyName = "IdGroup"
        Me.Cln_IdGroup.HeaderText = "IdGroup"
        Me.Cln_IdGroup.Name = "Cln_IdGroup"
        Me.Cln_IdGroup.ReadOnly = True
        Me.Cln_IdGroup.Visible = False
        '
        'Cln_IdOstan
        '
        Me.Cln_IdOstan.DataPropertyName = "IdOstan"
        Me.Cln_IdOstan.HeaderText = "IdOstan"
        Me.Cln_IdOstan.Name = "Cln_IdOstan"
        Me.Cln_IdOstan.ReadOnly = True
        Me.Cln_IdOstan.Visible = False
        '
        'Cln_IdCity
        '
        Me.Cln_IdCity.DataPropertyName = "IdCity"
        Me.Cln_IdCity.HeaderText = "IdCity"
        Me.Cln_IdCity.Name = "Cln_IdCity"
        Me.Cln_IdCity.ReadOnly = True
        Me.Cln_IdCity.Visible = False
        '
        'Cln_Idpart
        '
        Me.Cln_Idpart.DataPropertyName = "IdPart"
        Me.Cln_Idpart.HeaderText = "IdPart"
        Me.Cln_Idpart.Name = "Cln_Idpart"
        Me.Cln_Idpart.ReadOnly = True
        Me.Cln_Idpart.Visible = False
        '
        'Cln_IdVisitor
        '
        Me.Cln_IdVisitor.DataPropertyName = "IdVisitor"
        Me.Cln_IdVisitor.HeaderText = "IdVisitor"
        Me.Cln_IdVisitor.Name = "Cln_IdVisitor"
        Me.Cln_IdVisitor.ReadOnly = True
        Me.Cln_IdVisitor.Visible = False
        '
        'Cln_Adres
        '
        Me.Cln_Adres.DataPropertyName = "Adres"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Adres.DefaultCellStyle = DataGridViewCellStyle14
        Me.Cln_Adres.HeaderText = "آدرس"
        Me.Cln_Adres.Name = "Cln_Adres"
        Me.Cln_Adres.ReadOnly = True
        Me.Cln_Adres.Visible = False
        '
        'Mobile_ListPeople
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 564)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnDel)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "Mobile_ListPeople"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "طرف حساب موقت"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents BtnDel As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Cln_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Visitor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Nam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Tell1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Tell2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_groupnam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_NamO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_NamCI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_NamP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdOstan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdCity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Idpart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_IdVisitor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Adres As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
