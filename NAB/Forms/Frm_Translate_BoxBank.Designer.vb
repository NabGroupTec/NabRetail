<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Translate_BoxBank
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
        Me.CmbSanad = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtNumChk = New System.Windows.Forms.TextBox
        Me.Chk = New System.Windows.Forms.CheckBox
        Me.TxtBank = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtDiscT = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtMonT = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPayDate = New FarsiDate.FarsiDate
        Me.TxtIdBox = New System.Windows.Forms.TextBox
        Me.TxtIdbank = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnCancle = New System.Windows.Forms.Button
        Me.LEdit = New System.Windows.Forms.Label
        Me.LSanad = New System.Windows.Forms.Label
        Me.LBankMoein = New System.Windows.Forms.Label
        Me.LBoxMoein = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbSanad)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(344, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "نوع انتقال"
        '
        'CmbSanad
        '
        Me.CmbSanad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSanad.FormattingEnabled = True
        Me.CmbSanad.Items.AddRange(New Object() {"صندوق به بانک", "بانک به صندوق"})
        Me.CmbSanad.Location = New System.Drawing.Point(6, 23)
        Me.CmbSanad.Name = "CmbSanad"
        Me.CmbSanad.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CmbSanad.Size = New System.Drawing.Size(324, 29)
        Me.CmbSanad.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtNumChk)
        Me.GroupBox2.Controls.Add(Me.Chk)
        Me.GroupBox2.Controls.Add(Me.TxtBank)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtBox)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TxtDiscT)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TxtMonT)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TxtPayDate)
        Me.GroupBox2.Controls.Add(Me.TxtIdBox)
        Me.GroupBox2.Controls.Add(Me.TxtIdbank)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(344, 157)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "مشخصات انتقال"
        '
        'TxtNumChk
        '
        Me.TxtNumChk.Location = New System.Drawing.Point(6, 118)
        Me.TxtNumChk.Name = "TxtNumChk"
        Me.TxtNumChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNumChk.ShortcutsEnabled = False
        Me.TxtNumChk.Size = New System.Drawing.Size(121, 29)
        Me.TxtNumChk.TabIndex = 7
        Me.TxtNumChk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Chk
        '
        Me.Chk.AutoSize = True
        Me.Chk.Location = New System.Drawing.Point(134, 121)
        Me.Chk.Name = "Chk"
        Me.Chk.Size = New System.Drawing.Size(98, 25)
        Me.Chk.TabIndex = 6
        Me.Chk.Text = "استفاده از چک"
        Me.Chk.UseVisualStyleBackColor = True
        '
        'TxtBank
        '
        Me.TxtBank.Location = New System.Drawing.Point(6, 58)
        Me.TxtBank.Name = "TxtBank"
        Me.TxtBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBank.ShortcutsEnabled = False
        Me.TxtBank.Size = New System.Drawing.Size(121, 29)
        Me.TxtBank.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(131, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 21)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "بانک"
        '
        'TxtBox
        '
        Me.TxtBox.Location = New System.Drawing.Point(170, 58)
        Me.TxtBox.Name = "TxtBox"
        Me.TxtBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBox.ShortcutsEnabled = False
        Me.TxtBox.Size = New System.Drawing.Size(109, 29)
        Me.TxtBox.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(295, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 21)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "صندوق"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(285, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 21)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "توضیحات"
        '
        'TxtDiscT
        '
        Me.TxtDiscT.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDiscT.Location = New System.Drawing.Point(6, 88)
        Me.TxtDiscT.MaxLength = 100
        Me.TxtDiscT.Name = "TxtDiscT"
        Me.TxtDiscT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDiscT.Size = New System.Drawing.Size(273, 29)
        Me.TxtDiscT.TabIndex = 5
        Me.TxtDiscT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 21)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "مبلغ"
        '
        'TxtMonT
        '
        Me.TxtMonT.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMonT.Location = New System.Drawing.Point(6, 28)
        Me.TxtMonT.MaxLength = 20
        Me.TxtMonT.Name = "TxtMonT"
        Me.TxtMonT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtMonT.ShortcutsEnabled = False
        Me.TxtMonT.Size = New System.Drawing.Size(121, 29)
        Me.TxtMonT.TabIndex = 2
        Me.TxtMonT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(306, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "تاریخ"
        '
        'TxtPayDate
        '
        Me.TxtPayDate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtPayDate.Location = New System.Drawing.Point(170, 28)
        Me.TxtPayDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPayDate.Name = "TxtPayDate"
        Me.TxtPayDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtPayDate.Size = New System.Drawing.Size(109, 29)
        Me.TxtPayDate.TabIndex = 1
        Me.TxtPayDate.ThisText = Nothing
        '
        'TxtIdBox
        '
        Me.TxtIdBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdBox.Location = New System.Drawing.Point(199, 58)
        Me.TxtIdBox.Name = "TxtIdBox"
        Me.TxtIdBox.ReadOnly = True
        Me.TxtIdBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtIdBox.ShortcutsEnabled = False
        Me.TxtIdBox.Size = New System.Drawing.Size(52, 29)
        Me.TxtIdBox.TabIndex = 65
        '
        'TxtIdbank
        '
        Me.TxtIdbank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdbank.Location = New System.Drawing.Point(44, 58)
        Me.TxtIdbank.Name = "TxtIdbank"
        Me.TxtIdbank.ReadOnly = True
        Me.TxtIdbank.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtIdbank.ShortcutsEnabled = False
        Me.TxtIdbank.Size = New System.Drawing.Size(52, 29)
        Me.TxtIdbank.TabIndex = 66
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 277)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(363, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 32
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
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel7.Text = "F3 انصراف"
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
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.Location = New System.Drawing.Point(278, 239)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 30)
        Me.BtnSave.TabIndex = 8
        Me.BtnSave.Text = "ثبت"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCancle
        '
        Me.BtnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancle.Location = New System.Drawing.Point(197, 239)
        Me.BtnCancle.Name = "BtnCancle"
        Me.BtnCancle.Size = New System.Drawing.Size(75, 30)
        Me.BtnCancle.TabIndex = 9
        Me.BtnCancle.Text = "انصراف"
        Me.BtnCancle.UseVisualStyleBackColor = True
        '
        'LEdit
        '
        Me.LEdit.AutoSize = True
        Me.LEdit.Location = New System.Drawing.Point(367, 63)
        Me.LEdit.Name = "LEdit"
        Me.LEdit.Size = New System.Drawing.Size(0, 21)
        Me.LEdit.TabIndex = 67
        Me.LEdit.Visible = False
        '
        'LSanad
        '
        Me.LSanad.AutoSize = True
        Me.LSanad.Location = New System.Drawing.Point(365, 72)
        Me.LSanad.Name = "LSanad"
        Me.LSanad.Size = New System.Drawing.Size(0, 21)
        Me.LSanad.TabIndex = 67
        Me.LSanad.Visible = False
        '
        'LBankMoein
        '
        Me.LBankMoein.AutoSize = True
        Me.LBankMoein.Location = New System.Drawing.Point(15, 244)
        Me.LBankMoein.Name = "LBankMoein"
        Me.LBankMoein.Size = New System.Drawing.Size(0, 21)
        Me.LBankMoein.TabIndex = 67
        Me.LBankMoein.Visible = False
        '
        'LBoxMoein
        '
        Me.LBoxMoein.AutoSize = True
        Me.LBoxMoein.Location = New System.Drawing.Point(56, 244)
        Me.LBoxMoein.Name = "LBoxMoein"
        Me.LBoxMoein.Size = New System.Drawing.Size(0, 21)
        Me.LBoxMoein.TabIndex = 68
        Me.LBoxMoein.Visible = False
        '
        'Frm_Translate_BoxBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 306)
        Me.Controls.Add(Me.LBoxMoein)
        Me.Controls.Add(Me.LBankMoein)
        Me.Controls.Add(Me.LSanad)
        Me.Controls.Add(Me.LEdit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Translate_BoxBank"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "انتقالات بانک و صندوق"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbSanad As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPayDate As FarsiDate.FarsiDate
    Friend WithEvents TxtMonT As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscT As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumChk As System.Windows.Forms.TextBox
    Friend WithEvents Chk As System.Windows.Forms.CheckBox
    Friend WithEvents TxtBank As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnCancle As System.Windows.Forms.Button
    Friend WithEvents TxtIdBox As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdbank As System.Windows.Forms.TextBox
    Friend WithEvents LEdit As System.Windows.Forms.Label
    Friend WithEvents LSanad As System.Windows.Forms.Label
    Friend WithEvents LBankMoein As System.Windows.Forms.Label
    Friend WithEvents LBoxMoein As System.Windows.Forms.Label
End Class
