<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEndAccounting
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtNewPeriod = New System.Windows.Forms.TextBox
        Me.TxtOldPeriod = New System.Windows.Forms.TextBox
        Me.TxtAccount = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnSave = New System.Windows.Forms.Button
        Me.Picamval = New System.Windows.Forms.PictureBox
        Me.PicBox = New System.Windows.Forms.PictureBox
        Me.PicBank = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel
        Me.PicKala = New System.Windows.Forms.PictureBox
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel
        Me.PicSarmayeh = New System.Windows.Forms.PictureBox
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.BtnTraz = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnSearchpeople = New System.Windows.Forms.Button
        Me.CmbPeople = New System.Windows.Forms.ComboBox
        Me.ChkDelPeople = New System.Windows.Forms.CheckBox
        Me.BtnKala = New System.Windows.Forms.Button
        Me.ChkKala = New System.Windows.Forms.CheckBox
        Me.CmbKala = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ListKala = New System.Windows.Forms.Button
        Me.ListSearchpeople = New System.Windows.Forms.Button
        Me.BtnEdit = New System.Windows.Forms.Button
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1.SuspendLayout()
        CType(Me.Picamval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBank, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PicKala, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSarmayeh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtNewPeriod)
        Me.GroupBox1.Controls.Add(Me.TxtOldPeriod)
        Me.GroupBox1.Controls.Add(Me.TxtAccount)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(443, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "مشخصات دور مالی فعلی"
        '
        'TxtNewPeriod
        '
        Me.TxtNewPeriod.BackColor = System.Drawing.Color.White
        Me.TxtNewPeriod.Location = New System.Drawing.Point(6, 56)
        Me.TxtNewPeriod.Name = "TxtNewPeriod"
        Me.TxtNewPeriod.Size = New System.Drawing.Size(123, 29)
        Me.TxtNewPeriod.TabIndex = 5
        '
        'TxtOldPeriod
        '
        Me.TxtOldPeriod.BackColor = System.Drawing.Color.White
        Me.TxtOldPeriod.Enabled = False
        Me.TxtOldPeriod.Location = New System.Drawing.Point(228, 56)
        Me.TxtOldPeriod.Name = "TxtOldPeriod"
        Me.TxtOldPeriod.ReadOnly = True
        Me.TxtOldPeriod.Size = New System.Drawing.Size(123, 29)
        Me.TxtOldPeriod.TabIndex = 3
        '
        'TxtAccount
        '
        Me.TxtAccount.BackColor = System.Drawing.Color.White
        Me.TxtAccount.Enabled = False
        Me.TxtAccount.Location = New System.Drawing.Point(6, 25)
        Me.TxtAccount.Name = "TxtAccount"
        Me.TxtAccount.ReadOnly = True
        Me.TxtAccount.Size = New System.Drawing.Size(345, 29)
        Me.TxtAccount.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(357, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "دوره مالی فعلی"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(364, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "نام حسابداری"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(135, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "دوره مالی جدید"
        '
        'BtnSave
        '
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.Location = New System.Drawing.Point(244, 310)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(120, 33)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "بستن دوره مالی"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Picamval
        '
        Me.Picamval.Location = New System.Drawing.Point(226, 27)
        Me.Picamval.Name = "Picamval"
        Me.Picamval.Size = New System.Drawing.Size(30, 25)
        Me.Picamval.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picamval.TabIndex = 8
        Me.Picamval.TabStop = False
        '
        'PicBox
        '
        Me.PicBox.Location = New System.Drawing.Point(407, 27)
        Me.PicBox.Name = "PicBox"
        Me.PicBox.Size = New System.Drawing.Size(30, 25)
        Me.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBox.TabIndex = 9
        Me.PicBox.TabStop = False
        '
        'PicBank
        '
        Me.PicBank.Location = New System.Drawing.Point(407, 58)
        Me.PicBank.Name = "PicBank"
        Me.PicBank.Size = New System.Drawing.Size(30, 25)
        Me.PicBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBank.TabIndex = 10
        Me.PicBank.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel5)
        Me.GroupBox2.Controls.Add(Me.PicKala)
        Me.GroupBox2.Controls.Add(Me.LinkLabel4)
        Me.GroupBox2.Controls.Add(Me.PicSarmayeh)
        Me.GroupBox2.Controls.Add(Me.LinkLabel3)
        Me.GroupBox2.Controls.Add(Me.LinkLabel2)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.Picamval)
        Me.GroupBox2.Controls.Add(Me.PicBank)
        Me.GroupBox2.Controls.Add(Me.PicBox)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(443, 97)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " لیست مغایرت     ( علامت هشدار قرمز به معنای مغایرت است)"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Location = New System.Drawing.Point(148, 62)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(71, 21)
        Me.LinkLabel5.TabIndex = 17
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "موجودی انبار"
        '
        'PicKala
        '
        Me.PicKala.Location = New System.Drawing.Point(226, 58)
        Me.PicKala.Name = "PicKala"
        Me.PicKala.Size = New System.Drawing.Size(30, 25)
        Me.PicKala.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicKala.TabIndex = 16
        Me.PicKala.TabStop = False
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Location = New System.Drawing.Point(33, 31)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(44, 21)
        Me.LinkLabel4.TabIndex = 15
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "سرمایه"
        '
        'PicSarmayeh
        '
        Me.PicSarmayeh.Location = New System.Drawing.Point(84, 27)
        Me.PicSarmayeh.Name = "PicSarmayeh"
        Me.PicSarmayeh.Size = New System.Drawing.Size(30, 25)
        Me.PicSarmayeh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicSarmayeh.TabIndex = 14
        Me.PicSarmayeh.TabStop = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(187, 31)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(32, 21)
        Me.LinkLabel3.TabIndex = 13
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "اموال"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(326, 62)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(75, 21)
        Me.LinkLabel2.TabIndex = 12
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "موجودی بانک"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(312, 31)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(88, 21)
        Me.LinkLabel1.TabIndex = 11
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "موجودی صندوق"
        '
        'BtnTraz
        '
        Me.BtnTraz.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnTraz.Location = New System.Drawing.Point(124, 310)
        Me.BtnTraz.Name = "BtnTraz"
        Me.BtnTraz.Size = New System.Drawing.Size(120, 33)
        Me.BtnTraz.TabIndex = 12
        Me.BtnTraz.Text = "تراز اختتامیه"
        Me.BtnTraz.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 349)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(450, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 80
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel3.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(96, 24)
        Me.ToolStripStatusLabel2.Text = "F2 بستن دوره مالی"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(115, 24)
        Me.ToolStripStatusLabel4.Text = "F4 اصلاحیه طرف حساب"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'BtnSearchpeople
        '
        Me.BtnSearchpeople.Enabled = False
        Me.BtnSearchpeople.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSearchpeople.Location = New System.Drawing.Point(83, 26)
        Me.BtnSearchpeople.Name = "BtnSearchpeople"
        Me.BtnSearchpeople.Size = New System.Drawing.Size(51, 30)
        Me.BtnSearchpeople.TabIndex = 81
        Me.BtnSearchpeople.Text = "انتخاب"
        Me.BtnSearchpeople.UseVisualStyleBackColor = True
        '
        'CmbPeople
        '
        Me.CmbPeople.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPeople.Enabled = False
        Me.CmbPeople.FormattingEnabled = True
        Me.CmbPeople.Items.AddRange(New Object() {"بی حساب و غیر فعال", "بی حساب", "غیر فعال", "انتخابی"})
        Me.CmbPeople.Location = New System.Drawing.Point(135, 26)
        Me.CmbPeople.Name = "CmbPeople"
        Me.CmbPeople.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbPeople.Size = New System.Drawing.Size(168, 29)
        Me.CmbPeople.TabIndex = 81
        '
        'ChkDelPeople
        '
        Me.ChkDelPeople.AutoSize = True
        Me.ChkDelPeople.Location = New System.Drawing.Point(309, 28)
        Me.ChkDelPeople.Name = "ChkDelPeople"
        Me.ChkDelPeople.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkDelPeople.Size = New System.Drawing.Size(120, 25)
        Me.ChkDelPeople.TabIndex = 87
        Me.ChkDelPeople.Text = "حذف طرف حساب"
        Me.ChkDelPeople.UseVisualStyleBackColor = True
        '
        'BtnKala
        '
        Me.BtnKala.Enabled = False
        Me.BtnKala.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnKala.Location = New System.Drawing.Point(83, 57)
        Me.BtnKala.Name = "BtnKala"
        Me.BtnKala.Size = New System.Drawing.Size(51, 30)
        Me.BtnKala.TabIndex = 89
        Me.BtnKala.Text = "انتخاب"
        Me.BtnKala.UseVisualStyleBackColor = True
        '
        'ChkKala
        '
        Me.ChkKala.AutoSize = True
        Me.ChkKala.Location = New System.Drawing.Point(354, 60)
        Me.ChkKala.Name = "ChkKala"
        Me.ChkKala.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkKala.Size = New System.Drawing.Size(75, 25)
        Me.ChkKala.TabIndex = 90
        Me.ChkKala.Text = "حذف کالا"
        Me.ChkKala.UseVisualStyleBackColor = True
        '
        'CmbKala
        '
        Me.CmbKala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbKala.Enabled = False
        Me.CmbKala.FormattingEnabled = True
        Me.CmbKala.Items.AddRange(New Object() {"نداشتن موجودی و غیر فعال", "نداشتن موجودی", "غیر فعال", "انتخابی"})
        Me.CmbKala.Location = New System.Drawing.Point(135, 58)
        Me.CmbKala.Name = "CmbKala"
        Me.CmbKala.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbKala.Size = New System.Drawing.Size(168, 29)
        Me.CmbKala.TabIndex = 88
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ListKala)
        Me.GroupBox3.Controls.Add(Me.ListSearchpeople)
        Me.GroupBox3.Controls.Add(Me.CmbKala)
        Me.GroupBox3.Controls.Add(Me.BtnKala)
        Me.GroupBox3.Controls.Add(Me.CmbPeople)
        Me.GroupBox3.Controls.Add(Me.ChkKala)
        Me.GroupBox3.Controls.Add(Me.ChkDelPeople)
        Me.GroupBox3.Controls.Add(Me.BtnSearchpeople)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 209)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(443, 97)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "تنظیمات"
        '
        'ListKala
        '
        Me.ListKala.Enabled = False
        Me.ListKala.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ListKala.Location = New System.Drawing.Point(33, 57)
        Me.ListKala.Name = "ListKala"
        Me.ListKala.Size = New System.Drawing.Size(51, 30)
        Me.ListKala.TabIndex = 92
        Me.ListKala.Text = "لیست"
        Me.ListKala.UseVisualStyleBackColor = True
        '
        'ListSearchpeople
        '
        Me.ListSearchpeople.Enabled = False
        Me.ListSearchpeople.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ListSearchpeople.Location = New System.Drawing.Point(33, 26)
        Me.ListSearchpeople.Name = "ListSearchpeople"
        Me.ListSearchpeople.Size = New System.Drawing.Size(51, 30)
        Me.ListSearchpeople.TabIndex = 91
        Me.ListSearchpeople.Text = "لیست"
        Me.ListSearchpeople.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnEdit.Location = New System.Drawing.Point(4, 310)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(120, 33)
        Me.BtnEdit.TabIndex = 81
        Me.BtnEdit.Text = "اصلاحیه طرف حساب"
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(78, 24)
        Me.ToolStripStatusLabel1.Text = "F3 تراز اختتامیه"
        '
        'FrmEndAccounting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 378)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnTraz)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEndAccounting"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بستن دوره مالی"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Picamval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBank, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PicKala, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSarmayeh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtOldPeriod As System.Windows.Forms.TextBox
    Friend WithEvents TxtAccount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNewPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Picamval As System.Windows.Forms.PictureBox
    Friend WithEvents PicBox As System.Windows.Forms.PictureBox
    Friend WithEvents PicBank As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents PicSarmayeh As System.Windows.Forms.PictureBox
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents PicKala As System.Windows.Forms.PictureBox
    Friend WithEvents BtnTraz As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSearchpeople As System.Windows.Forms.Button
    Friend WithEvents CmbPeople As System.Windows.Forms.ComboBox
    Friend WithEvents ChkDelPeople As System.Windows.Forms.CheckBox
    Friend WithEvents BtnKala As System.Windows.Forms.Button
    Friend WithEvents ChkKala As System.Windows.Forms.CheckBox
    Friend WithEvents CmbKala As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ListKala As System.Windows.Forms.Button
    Friend WithEvents ListSearchpeople As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
End Class
