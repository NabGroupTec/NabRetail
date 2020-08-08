<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDaftarKolManual
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Cln_Ad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Bed = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Bes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_T = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_mandeh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Tell = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Mobile = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnMoein = New System.Windows.Forms.Button
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtMandeh = New System.Windows.Forms.TextBox
        Me.TxtT = New System.Windows.Forms.TextBox
        Me.TxtBed = New System.Windows.Forms.TextBox
        Me.TxtBes = New System.Windows.Forms.TextBox
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 541)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(864, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 65
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(106, 24)
        Me.ToolStripStatusLabel3.Text = "F2 معین طرف حساب"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel2.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Ad, Me.Cln_Name, Me.Cln_Bed, Me.Cln_Bes, Me.Cln_T, Me.Cln_mandeh, Me.Cln_Tell, Me.Cln_Mobile, Me.Cln_Id})
        Me.DGV.Location = New System.Drawing.Point(9, 12)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.Size = New System.Drawing.Size(846, 490)
        Me.DGV.TabIndex = 0
        '
        'Cln_Ad
        '
        Me.Cln_Ad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Ad.DataPropertyName = "Addres"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Ad.DefaultCellStyle = DataGridViewCellStyle9
        Me.Cln_Ad.HeaderText = "آدرس"
        Me.Cln_Ad.Name = "Cln_Ad"
        Me.Cln_Ad.ReadOnly = True
        Me.Cln_Ad.Width = 273
        '
        'Cln_Name
        '
        Me.Cln_Name.DataPropertyName = "Nam"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Name.DefaultCellStyle = DataGridViewCellStyle10
        Me.Cln_Name.HeaderText = "طرف حساب"
        Me.Cln_Name.Name = "Cln_Name"
        Me.Cln_Name.ReadOnly = True
        Me.Cln_Name.Width = 200
        '
        'Cln_Bed
        '
        Me.Cln_Bed.DataPropertyName = "BedMon"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.NullValue = "0"
        Me.Cln_Bed.DefaultCellStyle = DataGridViewCellStyle11
        Me.Cln_Bed.HeaderText = "بدهکار"
        Me.Cln_Bed.Name = "Cln_Bed"
        Me.Cln_Bed.ReadOnly = True
        '
        'Cln_Bes
        '
        Me.Cln_Bes.DataPropertyName = "BesMon"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = "0"
        Me.Cln_Bes.DefaultCellStyle = DataGridViewCellStyle12
        Me.Cln_Bes.HeaderText = "بستانکار"
        Me.Cln_Bes.Name = "Cln_Bes"
        Me.Cln_Bes.ReadOnly = True
        '
        'Cln_T
        '
        Me.Cln_T.DataPropertyName = "T"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_T.DefaultCellStyle = DataGridViewCellStyle13
        Me.Cln_T.HeaderText = "ت"
        Me.Cln_T.Name = "Cln_T"
        Me.Cln_T.ReadOnly = True
        Me.Cln_T.Width = 30
        '
        'Cln_mandeh
        '
        Me.Cln_mandeh.DataPropertyName = "Mandeh"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = "0"
        Me.Cln_mandeh.DefaultCellStyle = DataGridViewCellStyle14
        Me.Cln_mandeh.HeaderText = "مانده"
        Me.Cln_mandeh.Name = "Cln_mandeh"
        Me.Cln_mandeh.ReadOnly = True
        '
        'Cln_Tell
        '
        Me.Cln_Tell.DataPropertyName = "Fix"
        Me.Cln_Tell.HeaderText = "تلفن ثابت"
        Me.Cln_Tell.Name = "Cln_Tell"
        Me.Cln_Tell.ReadOnly = True
        Me.Cln_Tell.Visible = False
        '
        'Cln_Mobile
        '
        Me.Cln_Mobile.DataPropertyName = "Mobile"
        Me.Cln_Mobile.HeaderText = "موبایل"
        Me.Cln_Mobile.Name = "Cln_Mobile"
        Me.Cln_Mobile.ReadOnly = True
        Me.Cln_Mobile.Visible = False
        '
        'Cln_Id
        '
        Me.Cln_Id.DataPropertyName = "Id"
        Me.Cln_Id.HeaderText = "کد"
        Me.Cln_Id.Name = "Cln_Id"
        Me.Cln_Id.ReadOnly = True
        Me.Cln_Id.Visible = False
        '
        'BtnMoein
        '
        Me.BtnMoein.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMoein.Location = New System.Drawing.Point(736, 505)
        Me.BtnMoein.Name = "BtnMoein"
        Me.BtnMoein.Size = New System.Drawing.Size(119, 30)
        Me.BtnMoein.TabIndex = 66
        Me.BtnMoein.Text = "معین طرف حساب"
        Me.BtnMoein.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSearch.Location = New System.Drawing.Point(611, 506)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(119, 30)
        Me.BtnSearch.TabIndex = 67
        Me.BtnSearch.Text = "جستجو"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(59, 24)
        Me.ToolStripStatusLabel4.Text = "F3 جستجو"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(367, 510)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 21)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "وضعیت نهایی"
        '
        'TxtMandeh
        '
        Me.TxtMandeh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtMandeh.BackColor = System.Drawing.Color.White
        Me.TxtMandeh.Location = New System.Drawing.Point(29, 508)
        Me.TxtMandeh.Name = "TxtMandeh"
        Me.TxtMandeh.ReadOnly = True
        Me.TxtMandeh.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtMandeh.Size = New System.Drawing.Size(102, 29)
        Me.TxtMandeh.TabIndex = 90
        Me.TxtMandeh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtT
        '
        Me.TxtT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT.BackColor = System.Drawing.Color.White
        Me.TxtT.Location = New System.Drawing.Point(130, 508)
        Me.TxtT.Name = "TxtT"
        Me.TxtT.ReadOnly = True
        Me.TxtT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtT.Size = New System.Drawing.Size(31, 29)
        Me.TxtT.TabIndex = 89
        Me.TxtT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtBed
        '
        Me.TxtBed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtBed.BackColor = System.Drawing.Color.White
        Me.TxtBed.Location = New System.Drawing.Point(260, 508)
        Me.TxtBed.Name = "TxtBed"
        Me.TxtBed.ReadOnly = True
        Me.TxtBed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBed.Size = New System.Drawing.Size(101, 29)
        Me.TxtBed.TabIndex = 88
        Me.TxtBed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtBes
        '
        Me.TxtBes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtBes.BackColor = System.Drawing.Color.White
        Me.TxtBes.Location = New System.Drawing.Point(160, 508)
        Me.TxtBes.Name = "TxtBes"
        Me.TxtBes.ReadOnly = True
        Me.TxtBes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBes.Size = New System.Drawing.Size(101, 29)
        Me.TxtBes.TabIndex = 86
        Me.TxtBes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmDaftarKolManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 570)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtMandeh)
        Me.Controls.Add(Me.TxtT)
        Me.Controls.Add(Me.TxtBed)
        Me.Controls.Add(Me.TxtBes)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.BtnMoein)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmDaftarKolManual"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "دفتر کل"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BtnMoein As System.Windows.Forms.Button
    Friend WithEvents Cln_Ad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Bed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Bes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_T As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_mandeh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Tell As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Mobile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtMandeh As System.Windows.Forms.TextBox
    Friend WithEvents TxtT As System.Windows.Forms.TextBox
    Friend WithEvents TxtBed As System.Windows.Forms.TextBox
    Friend WithEvents TxtBes As System.Windows.Forms.TextBox
End Class
