<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeldProductionList
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
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnMeldProduct = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvFormulas = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearche = New System.Windows.Forms.TextBox()
        Me.rdoFormulDate = New System.Windows.Forms.RadioButton()
        Me.rdoFilterFormulName = New System.Windows.Forms.RadioButton()
        Me.rdoFilterCodeFormul = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbFormula = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cln_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_FCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Count = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_UserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvFormulas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(73, 26)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(78, 26)
        Me.ToolStripStatusLabel5.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(61, 26)
        Me.ToolStripStatusLabel4.Text = "F4 حذف"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(74, 26)
        Me.ToolStripStatusLabel3.Text = "F3 ویرایش"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(62, 26)
        Me.ToolStripStatusLabel2.Text = "F2 جدید"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(65, 26)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'btnMeldProduct
        '
        Me.btnMeldProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMeldProduct.Location = New System.Drawing.Point(384, 420)
        Me.btnMeldProduct.Name = "btnMeldProduct"
        Me.btnMeldProduct.Size = New System.Drawing.Size(87, 39)
        Me.btnMeldProduct.TabIndex = 39
        Me.btnMeldProduct.Text = "اعلام تولید"
        Me.btnMeldProduct.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("IRANSans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 477)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(822, 31)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 40
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(88, 26)
        Me.ToolStripStatusLabel6.Text = "F6 اعلام تولید"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(12, 420)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 39)
        Me.btnCancel.TabIndex = 38
        Me.btnCancel.Text = "انصراف"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(105, 420)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 39)
        Me.btnDelete.TabIndex = 37
        Me.btnDelete.Text = "حذف"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Location = New System.Drawing.Point(198, 420)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(87, 39)
        Me.btnEdit.TabIndex = 35
        Me.btnEdit.Text = "ویرایش"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(291, 420)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(87, 39)
        Me.btnAdd.TabIndex = 33
        Me.btnAdd.Text = "جدید"
        Me.btnAdd.UseVisualStyleBackColor = True
        Me.btnAdd.Visible = False
        '
        'dgvFormulas
        '
        Me.dgvFormulas.AllowUserToAddRows = False
        Me.dgvFormulas.AllowUserToDeleteRows = False
        Me.dgvFormulas.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvFormulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFormulas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Id, Me.Cln_FCode, Me.Cln_Name, Me.Cln_Count, Me.Cln_UserName, Me.Cln_Date})
        Me.dgvFormulas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFormulas.Location = New System.Drawing.Point(3, 26)
        Me.dgvFormulas.Name = "dgvFormulas"
        Me.dgvFormulas.ReadOnly = True
        Me.dgvFormulas.Size = New System.Drawing.Size(792, 246)
        Me.dgvFormulas.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvFormulas)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(798, 275)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "لیست"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("IRANSans", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(136, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "عبارت را اینجا وارد نمائید"
        '
        'txtSearche
        '
        Me.txtSearche.Location = New System.Drawing.Point(6, 42)
        Me.txtSearche.Name = "txtSearche"
        Me.txtSearche.Size = New System.Drawing.Size(253, 30)
        Me.txtSearche.TabIndex = 3
        '
        'rdoFormulDate
        '
        Me.rdoFormulDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoFormulDate.AutoSize = True
        Me.rdoFormulDate.Location = New System.Drawing.Point(353, 31)
        Me.rdoFormulDate.Name = "rdoFormulDate"
        Me.rdoFormulDate.Size = New System.Drawing.Size(100, 26)
        Me.rdoFormulDate.TabIndex = 2
        Me.rdoFormulDate.TabStop = True
        Me.rdoFormulDate.Text = "براساس تاریخ"
        Me.rdoFormulDate.UseVisualStyleBackColor = True
        '
        'rdoFilterFormulName
        '
        Me.rdoFilterFormulName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoFilterFormulName.AutoSize = True
        Me.rdoFilterFormulName.Location = New System.Drawing.Point(487, 31)
        Me.rdoFilterFormulName.Name = "rdoFilterFormulName"
        Me.rdoFilterFormulName.Size = New System.Drawing.Size(122, 26)
        Me.rdoFilterFormulName.TabIndex = 1
        Me.rdoFilterFormulName.TabStop = True
        Me.rdoFilterFormulName.Text = "براساس نام فرمول"
        Me.rdoFilterFormulName.UseVisualStyleBackColor = True
        '
        'rdoFilterCodeFormul
        '
        Me.rdoFilterCodeFormul.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoFilterCodeFormul.AutoSize = True
        Me.rdoFilterCodeFormul.Location = New System.Drawing.Point(625, 31)
        Me.rdoFilterCodeFormul.Name = "rdoFilterCodeFormul"
        Me.rdoFilterCodeFormul.Size = New System.Drawing.Size(158, 26)
        Me.rdoFilterCodeFormul.TabIndex = 0
        Me.rdoFilterCodeFormul.TabStop = True
        Me.rdoFilterCodeFormul.Text = "بر اساس کد دستی فرمول"
        Me.rdoFilterCodeFormul.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSearche)
        Me.GroupBox1.Controls.Add(Me.rdoFormulDate)
        Me.GroupBox1.Controls.Add(Me.rdoFilterFormulName)
        Me.GroupBox1.Controls.Add(Me.rdoFilterCodeFormul)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(798, 78)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "فیلتر"
        '
        'CmbFormula
        '
        Me.CmbFormula.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CmbFormula.FormattingEnabled = True
        Me.CmbFormula.Location = New System.Drawing.Point(12, 371)
        Me.CmbFormula.Name = "CmbFormula"
        Me.CmbFormula.Size = New System.Drawing.Size(242, 30)
        Me.CmbFormula.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(260, 374)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(178, 22)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "انتخاب فرمول جهت اعلام تولید :"
        '
        'Cln_Id
        '
        Me.Cln_Id.DataPropertyName = "Id"
        Me.Cln_Id.HeaderText = "کد سیستم"
        Me.Cln_Id.Name = "Cln_Id"
        Me.Cln_Id.ReadOnly = True
        '
        'Cln_FCode
        '
        Me.Cln_FCode.DataPropertyName = "FormulId"
        Me.Cln_FCode.HeaderText = "کد فرمول"
        Me.Cln_FCode.Name = "Cln_FCode"
        Me.Cln_FCode.ReadOnly = True
        '
        'Cln_Name
        '
        Me.Cln_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Cln_Name.DataPropertyName = "FormulName"
        Me.Cln_Name.HeaderText = "نام فرمول"
        Me.Cln_Name.Name = "Cln_Name"
        Me.Cln_Name.ReadOnly = True
        '
        'Cln_Count
        '
        Me.Cln_Count.DataPropertyName = "CountTavlid"
        Me.Cln_Count.HeaderText = "تعداد تولید"
        Me.Cln_Count.Name = "Cln_Count"
        Me.Cln_Count.ReadOnly = True
        '
        'Cln_UserName
        '
        Me.Cln_UserName.DataPropertyName = "Nam"
        Me.Cln_UserName.HeaderText = "کاربر"
        Me.Cln_UserName.Name = "Cln_UserName"
        Me.Cln_UserName.ReadOnly = True
        '
        'Cln_Date
        '
        Me.Cln_Date.DataPropertyName = "D_Date"
        Me.Cln_Date.HeaderText = "تاریخ سند"
        Me.Cln_Date.Name = "Cln_Date"
        Me.Cln_Date.ReadOnly = True
        '
        'FrmMeldProductionList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(822, 508)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbFormula)
        Me.Controls.Add(Me.btnMeldProduct)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("IRANSans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmMeldProductionList"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "لیست اعلام تولیدها"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvFormulas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnMeldProduct As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgvFormulas As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearche As System.Windows.Forms.TextBox
    Friend WithEvents rdoFormulDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFilterFormulName As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFilterCodeFormul As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbFormula As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cln_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_FCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Count As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_UserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Date As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
