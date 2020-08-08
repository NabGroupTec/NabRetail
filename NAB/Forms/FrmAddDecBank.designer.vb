<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddDecBank
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtDiscT = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtMonT = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPayDate = New FarsiDate.FarsiDate
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RdoAdd = New System.Windows.Forms.RadioButton
        Me.RdoDec = New System.Windows.Forms.RadioButton
        Me.TxtBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtIdBox = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnCancle = New System.Windows.Forms.Button
        Me.LEdit = New System.Windows.Forms.Label
        Me.LSanad = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(174, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 21)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "توضیحات"
        '
        'TxtDiscT
        '
        Me.TxtDiscT.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDiscT.Location = New System.Drawing.Point(13, 58)
        Me.TxtDiscT.MaxLength = 100
        Me.TxtDiscT.Name = "TxtDiscT"
        Me.TxtDiscT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDiscT.Size = New System.Drawing.Size(155, 29)
        Me.TxtDiscT.TabIndex = 4
        Me.TxtDiscT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 21)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "مبلغ"
        '
        'TxtMonT
        '
        Me.TxtMonT.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMonT.Location = New System.Drawing.Point(13, 28)
        Me.TxtMonT.MaxLength = 20
        Me.TxtMonT.Name = "TxtMonT"
        Me.TxtMonT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtMonT.ShortcutsEnabled = False
        Me.TxtMonT.Size = New System.Drawing.Size(155, 29)
        Me.TxtMonT.TabIndex = 2
        Me.TxtMonT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(360, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 21)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "تاریخ"
        '
        'TxtPayDate
        '
        Me.TxtPayDate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtPayDate.Location = New System.Drawing.Point(237, 58)
        Me.TxtPayDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPayDate.Name = "TxtPayDate"
        Me.TxtPayDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtPayDate.Size = New System.Drawing.Size(119, 29)
        Me.TxtPayDate.TabIndex = 3
        Me.TxtPayDate.ThisText = Nothing
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdoAdd)
        Me.GroupBox1.Controls.Add(Me.RdoDec)
        Me.GroupBox1.Controls.Add(Me.TxtBox)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtIdBox)
        Me.GroupBox1.Controls.Add(Me.TxtDiscT)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtPayDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtMonT)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(410, 124)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'RdoAdd
        '
        Me.RdoAdd.AutoSize = True
        Me.RdoAdd.Location = New System.Drawing.Point(104, 93)
        Me.RdoAdd.Name = "RdoAdd"
        Me.RdoAdd.Size = New System.Drawing.Size(64, 25)
        Me.RdoAdd.TabIndex = 5
        Me.RdoAdd.TabStop = True
        Me.RdoAdd.Text = "اضافات"
        Me.RdoAdd.UseVisualStyleBackColor = True
        '
        'RdoDec
        '
        Me.RdoDec.AutoSize = True
        Me.RdoDec.Location = New System.Drawing.Point(13, 93)
        Me.RdoDec.Name = "RdoDec"
        Me.RdoDec.Size = New System.Drawing.Size(69, 25)
        Me.RdoDec.TabIndex = 6
        Me.RdoDec.TabStop = True
        Me.RdoDec.Text = "کسورات"
        Me.RdoDec.UseVisualStyleBackColor = True
        '
        'TxtBox
        '
        Me.TxtBox.Location = New System.Drawing.Point(237, 28)
        Me.TxtBox.MaxLength = 100
        Me.TxtBox.Name = "TxtBox"
        Me.TxtBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBox.ShortcutsEnabled = False
        Me.TxtBox.Size = New System.Drawing.Size(119, 29)
        Me.TxtBox.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(362, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 21)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "بانک"
        '
        'TxtIdBox
        '
        Me.TxtIdBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdBox.Location = New System.Drawing.Point(266, 28)
        Me.TxtIdBox.Name = "TxtIdBox"
        Me.TxtIdBox.ReadOnly = True
        Me.TxtIdBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtIdBox.ShortcutsEnabled = False
        Me.TxtIdBox.Size = New System.Drawing.Size(52, 29)
        Me.TxtIdBox.TabIndex = 68
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 172)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(433, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 33
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
        Me.BtnSave.Location = New System.Drawing.Point(346, 130)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 30)
        Me.BtnSave.TabIndex = 7
        Me.BtnSave.Text = "ثبت"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCancle
        '
        Me.BtnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancle.Location = New System.Drawing.Point(265, 130)
        Me.BtnCancle.Name = "BtnCancle"
        Me.BtnCancle.Size = New System.Drawing.Size(75, 30)
        Me.BtnCancle.TabIndex = 8
        Me.BtnCancle.Text = "انصراف"
        Me.BtnCancle.UseVisualStyleBackColor = True
        '
        'LEdit
        '
        Me.LEdit.AutoSize = True
        Me.LEdit.Location = New System.Drawing.Point(24, 139)
        Me.LEdit.Name = "LEdit"
        Me.LEdit.Size = New System.Drawing.Size(0, 21)
        Me.LEdit.TabIndex = 69
        Me.LEdit.Visible = False
        '
        'LSanad
        '
        Me.LSanad.AutoSize = True
        Me.LSanad.Location = New System.Drawing.Point(24, 135)
        Me.LSanad.Name = "LSanad"
        Me.LSanad.Size = New System.Drawing.Size(0, 21)
        Me.LSanad.TabIndex = 70
        Me.LSanad.Visible = False
        '
        'FrmAddDecBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 201)
        Me.Controls.Add(Me.LSanad)
        Me.Controls.Add(Me.LEdit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddDecBank"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافات و کسورات بانک"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDiscT As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtMonT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPayDate As FarsiDate.FarsiDate
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoAdd As System.Windows.Forms.RadioButton
    Friend WithEvents RdoDec As System.Windows.Forms.RadioButton
    Friend WithEvents TxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtIdBox As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnCancle As System.Windows.Forms.Button
    Friend WithEvents LEdit As System.Windows.Forms.Label
    Friend WithEvents LSanad As System.Windows.Forms.Label
End Class
