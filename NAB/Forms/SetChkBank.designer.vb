<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetChkBank
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txtmon2 = New System.Windows.Forms.TextBox()
        Me.Txtmon1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Cmbtype = New System.Windows.Forms.ComboBox()
        Me.BtnCan = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Lnam = New System.Windows.Forms.Label()
        Me.Lnum = New System.Windows.Forms.Label()
        Me.Ledit = New System.Windows.Forms.Label()
        Me.LID = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LName = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label12.Location = New System.Drawing.Point(97, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label12.Size = New System.Drawing.Size(52, 21)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "تا شماره"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label13.Location = New System.Drawing.Point(246, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label13.Size = New System.Drawing.Size(51, 21)
        Me.Label13.TabIndex = 74
        Me.Label13.Text = "از شماره"
        '
        'Txtmon2
        '
        Me.Txtmon2.BackColor = System.Drawing.SystemColors.Window
        Me.Txtmon2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Txtmon2.Location = New System.Drawing.Point(10, 46)
        Me.Txtmon2.MaxLength = 9
        Me.Txtmon2.Name = "Txtmon2"
        Me.Txtmon2.ReadOnly = True
        Me.Txtmon2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Txtmon2.Size = New System.Drawing.Size(81, 29)
        Me.Txtmon2.TabIndex = 72
        Me.Txtmon2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Txtmon1
        '
        Me.Txtmon1.BackColor = System.Drawing.SystemColors.Window
        Me.Txtmon1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Txtmon1.Location = New System.Drawing.Point(153, 46)
        Me.Txtmon1.MaxLength = 8
        Me.Txtmon1.Name = "Txtmon1"
        Me.Txtmon1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Txtmon1.Size = New System.Drawing.Size(81, 29)
        Me.Txtmon1.TabIndex = 71
        Me.Txtmon1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.Location = New System.Drawing.Point(240, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label11.Size = New System.Drawing.Size(58, 21)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "دسته چک"
        '
        'Cmbtype
        '
        Me.Cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbtype.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Cmbtype.FormattingEnabled = True
        Me.Cmbtype.Items.AddRange(New Object() {"10", "25", "50", "100"})
        Me.Cmbtype.Location = New System.Drawing.Point(10, 14)
        Me.Cmbtype.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Cmbtype.Name = "Cmbtype"
        Me.Cmbtype.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Cmbtype.Size = New System.Drawing.Size(224, 29)
        Me.Cmbtype.TabIndex = 70
        '
        'BtnCan
        '
        Me.BtnCan.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnCan.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCan.Location = New System.Drawing.Point(92, 81)
        Me.BtnCan.Name = "BtnCan"
        Me.BtnCan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnCan.Size = New System.Drawing.Size(75, 30)
        Me.BtnCan.TabIndex = 77
        Me.BtnCan.Text = "انصراف"
        Me.BtnCan.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.Location = New System.Drawing.Point(11, 81)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnSave.Size = New System.Drawing.Size(75, 30)
        Me.BtnSave.TabIndex = 76
        Me.BtnSave.Text = "ثبت"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Lnam
        '
        Me.Lnam.AutoSize = True
        Me.Lnam.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lnam.Location = New System.Drawing.Point(155, 86)
        Me.Lnam.Name = "Lnam"
        Me.Lnam.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Lnam.Size = New System.Drawing.Size(0, 21)
        Me.Lnam.TabIndex = 78
        Me.Lnam.Visible = False
        '
        'Lnum
        '
        Me.Lnum.AutoSize = True
        Me.Lnum.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Lnum.Location = New System.Drawing.Point(170, 86)
        Me.Lnum.Name = "Lnum"
        Me.Lnum.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Lnum.Size = New System.Drawing.Size(0, 21)
        Me.Lnum.TabIndex = 79
        Me.Lnum.Visible = False
        '
        'Ledit
        '
        Me.Ledit.AutoSize = True
        Me.Ledit.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Ledit.Location = New System.Drawing.Point(179, 94)
        Me.Ledit.Name = "Ledit"
        Me.Ledit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Ledit.Size = New System.Drawing.Size(0, 21)
        Me.Ledit.TabIndex = 80
        Me.Ledit.Visible = False
        '
        'LID
        '
        Me.LID.AutoSize = True
        Me.LID.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LID.Location = New System.Drawing.Point(267, 86)
        Me.LID.Name = "LID"
        Me.LID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LID.Size = New System.Drawing.Size(0, 21)
        Me.LID.TabIndex = 81
        Me.LID.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 115)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(298, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 82
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
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel3.Text = "F3 انصراف"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel4.Text = "Esc خروج"
        '
        'LName
        '
        Me.LName.AutoSize = True
        Me.LName.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LName.Location = New System.Drawing.Point(235, 86)
        Me.LName.Name = "LName"
        Me.LName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LName.Size = New System.Drawing.Size(0, 21)
        Me.LName.TabIndex = 83
        Me.LName.Visible = False
        '
        'SetChkBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 144)
        Me.Controls.Add(Me.LName)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.LID)
        Me.Controls.Add(Me.Ledit)
        Me.Controls.Add(Me.Lnum)
        Me.Controls.Add(Me.Lnam)
        Me.Controls.Add(Me.BtnCan)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Txtmon2)
        Me.Controls.Add(Me.Txtmon1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Cmbtype)
        Me.Font = New System.Drawing.Font("Titr", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetChkBank"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اخذ دسته چک"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Txtmon2 As System.Windows.Forms.TextBox
    Friend WithEvents Txtmon1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCan As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Lnam As System.Windows.Forms.Label
    Friend WithEvents Lnum As System.Windows.Forms.Label
    Friend WithEvents Ledit As System.Windows.Forms.Label
    Friend WithEvents LID As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LName As System.Windows.Forms.Label
End Class
