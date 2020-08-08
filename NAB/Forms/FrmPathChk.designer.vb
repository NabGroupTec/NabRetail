<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPathChk
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
        Me.RdoF = New System.Windows.Forms.RadioButton
        Me.Rdopaychk = New System.Windows.Forms.RadioButton
        Me.Rdogetchk = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Rdosanad = New System.Windows.Forms.RadioButton
        Me.Rdonumchk = New System.Windows.Forms.RadioButton
        Me.TxtChk = New System.Windows.Forms.TextBox
        Me.Lbank = New System.Windows.Forms.Label
        Me.Lchk = New System.Windows.Forms.Label
        Me.Lsanad = New System.Windows.Forms.Label
        Me.Txtsanad = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cbobank = New System.Windows.Forms.TextBox
        Me.Txtidbank = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdoF)
        Me.GroupBox1.Controls.Add(Me.Rdopaychk)
        Me.GroupBox1.Controls.Add(Me.Rdogetchk)
        Me.GroupBox1.Location = New System.Drawing.Point(248, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(279, 69)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "نوع چک"
        '
        'RdoF
        '
        Me.RdoF.AutoSize = True
        Me.RdoF.Location = New System.Drawing.Point(7, 27)
        Me.RdoF.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.RdoF.Name = "RdoF"
        Me.RdoF.Size = New System.Drawing.Size(75, 25)
        Me.RdoF.TabIndex = 2
        Me.RdoF.TabStop = True
        Me.RdoF.Text = "خرج شده"
        Me.RdoF.UseVisualStyleBackColor = True
        '
        'Rdopaychk
        '
        Me.Rdopaychk.AutoSize = True
        Me.Rdopaychk.Location = New System.Drawing.Point(101, 27)
        Me.Rdopaychk.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Rdopaychk.Name = "Rdopaychk"
        Me.Rdopaychk.Size = New System.Drawing.Size(66, 25)
        Me.Rdopaychk.TabIndex = 1
        Me.Rdopaychk.TabStop = True
        Me.Rdopaychk.Text = "پرداختی"
        Me.Rdopaychk.UseVisualStyleBackColor = True
        '
        'Rdogetchk
        '
        Me.Rdogetchk.AutoSize = True
        Me.Rdogetchk.Location = New System.Drawing.Point(195, 27)
        Me.Rdogetchk.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Rdogetchk.Name = "Rdogetchk"
        Me.Rdogetchk.Size = New System.Drawing.Size(66, 25)
        Me.Rdogetchk.TabIndex = 0
        Me.Rdogetchk.TabStop = True
        Me.Rdogetchk.Text = "دريافتی"
        Me.Rdogetchk.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Rdosanad)
        Me.GroupBox2.Controls.Add(Me.Rdonumchk)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 0)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(231, 69)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "نوع جستجو"
        '
        'Rdosanad
        '
        Me.Rdosanad.AutoSize = True
        Me.Rdosanad.Location = New System.Drawing.Point(8, 27)
        Me.Rdosanad.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Rdosanad.Name = "Rdosanad"
        Me.Rdosanad.Size = New System.Drawing.Size(82, 25)
        Me.Rdosanad.TabIndex = 4
        Me.Rdosanad.TabStop = True
        Me.Rdosanad.Text = "شماره سند"
        Me.Rdosanad.UseVisualStyleBackColor = True
        '
        'Rdonumchk
        '
        Me.Rdonumchk.AutoSize = True
        Me.Rdonumchk.Location = New System.Drawing.Point(129, 27)
        Me.Rdonumchk.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Rdonumchk.Name = "Rdonumchk"
        Me.Rdonumchk.Size = New System.Drawing.Size(80, 25)
        Me.Rdonumchk.TabIndex = 3
        Me.Rdonumchk.TabStop = True
        Me.Rdonumchk.Text = "شماره چک"
        Me.Rdonumchk.UseVisualStyleBackColor = True
        '
        'TxtChk
        '
        Me.TxtChk.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtChk.Location = New System.Drawing.Point(308, 25)
        Me.TxtChk.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtChk.MaxLength = 9
        Me.TxtChk.Name = "TxtChk"
        Me.TxtChk.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtChk.Size = New System.Drawing.Size(114, 29)
        Me.TxtChk.TabIndex = 75
        Me.TxtChk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Lbank
        '
        Me.Lbank.AutoSize = True
        Me.Lbank.Location = New System.Drawing.Point(219, 29)
        Me.Lbank.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbank.Name = "Lbank"
        Me.Lbank.Size = New System.Drawing.Size(50, 21)
        Me.Lbank.TabIndex = 76
        Me.Lbank.Text = "نام بانک"
        '
        'Lchk
        '
        Me.Lchk.AutoSize = True
        Me.Lchk.Location = New System.Drawing.Point(442, 29)
        Me.Lchk.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lchk.Name = "Lchk"
        Me.Lchk.Size = New System.Drawing.Size(62, 21)
        Me.Lchk.TabIndex = 77
        Me.Lchk.Text = "شماره چک"
        '
        'Lsanad
        '
        Me.Lsanad.AutoSize = True
        Me.Lsanad.Location = New System.Drawing.Point(440, 29)
        Me.Lsanad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lsanad.Name = "Lsanad"
        Me.Lsanad.Size = New System.Drawing.Size(64, 21)
        Me.Lsanad.TabIndex = 79
        Me.Lsanad.Text = "شماره سند"
        '
        'Txtsanad
        '
        Me.Txtsanad.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Txtsanad.Location = New System.Drawing.Point(308, 25)
        Me.Txtsanad.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txtsanad.MaxLength = 9
        Me.Txtsanad.Name = "Txtsanad"
        Me.Txtsanad.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Txtsanad.Size = New System.Drawing.Size(114, 29)
        Me.Txtsanad.TabIndex = 5
        Me.Txtsanad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbobank)
        Me.GroupBox3.Controls.Add(Me.Lsanad)
        Me.GroupBox3.Controls.Add(Me.Lbank)
        Me.GroupBox3.Controls.Add(Me.Txtsanad)
        Me.GroupBox3.Controls.Add(Me.TxtChk)
        Me.GroupBox3.Controls.Add(Me.Lchk)
        Me.GroupBox3.Controls.Add(Me.Txtidbank)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 76)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(517, 69)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "عبارت جستجو"
        '
        'cbobank
        '
        Me.cbobank.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cbobank.Location = New System.Drawing.Point(8, 25)
        Me.cbobank.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbobank.MaxLength = 9
        Me.cbobank.Name = "cbobank"
        Me.cbobank.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cbobank.Size = New System.Drawing.Size(201, 29)
        Me.cbobank.TabIndex = 6
        '
        'Txtidbank
        '
        Me.Txtidbank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtidbank.Font = New System.Drawing.Font("B Titr", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Txtidbank.Location = New System.Drawing.Point(99, 25)
        Me.Txtidbank.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txtidbank.MaxLength = 9
        Me.Txtidbank.Name = "Txtidbank"
        Me.Txtidbank.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Txtidbank.Size = New System.Drawing.Size(49, 29)
        Me.Txtidbank.TabIndex = 81
        Me.Txtidbank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txtidbank.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(427, 151)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 31)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "تهيه گزارش"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 190)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(536, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 62
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(80, 24)
        Me.ToolStripStatusLabel2.Text = "F2 تهیه گزارش"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'FrmPathChk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 219)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPathChk"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش سابقه چک"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdopaychk As System.Windows.Forms.RadioButton
    Friend WithEvents Rdogetchk As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdosanad As System.Windows.Forms.RadioButton
    Friend WithEvents Rdonumchk As System.Windows.Forms.RadioButton
    Friend WithEvents TxtChk As System.Windows.Forms.TextBox
    Friend WithEvents Lbank As System.Windows.Forms.Label
    Friend WithEvents Lchk As System.Windows.Forms.Label
    Friend WithEvents Lsanad As System.Windows.Forms.Label
    Friend WithEvents Txtsanad As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RdoF As System.Windows.Forms.RadioButton
    Friend WithEvents cbobank As System.Windows.Forms.TextBox
    Friend WithEvents Txtidbank As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
End Class
