<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditRasChk
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
        Me.Txtmon = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LDate = New System.Windows.Forms.Label
        Me.LTime = New System.Windows.Forms.Label
        Me.TxtPayDate = New FarsiDate.FarsiDate
        Me.BtnOk = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.LOne = New System.Windows.Forms.Label
        Me.Ledit = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txtmon
        '
        Me.Txtmon.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Txtmon.Location = New System.Drawing.Point(7, 11)
        Me.Txtmon.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Txtmon.MaxLength = 16
        Me.Txtmon.Name = "Txtmon"
        Me.Txtmon.ShortcutsEnabled = False
        Me.Txtmon.Size = New System.Drawing.Size(112, 29)
        Me.Txtmon.TabIndex = 1
        Me.Txtmon.Text = "0"
        Me.Txtmon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 21)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "مبلغ"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(330, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 21)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "سر رسید"
        '
        'LDate
        '
        Me.LDate.BackColor = System.Drawing.Color.Transparent
        Me.LDate.Location = New System.Drawing.Point(3, 45)
        Me.LDate.Name = "LDate"
        Me.LDate.Size = New System.Drawing.Size(378, 21)
        Me.LDate.TabIndex = 62
        Me.LDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LTime
        '
        Me.LTime.BackColor = System.Drawing.Color.Transparent
        Me.LTime.Location = New System.Drawing.Point(168, 10)
        Me.LTime.Name = "LTime"
        Me.LTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LTime.Size = New System.Drawing.Size(57, 29)
        Me.LTime.TabIndex = 63
        Me.LTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtPayDate
        '
        Me.TxtPayDate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtPayDate.Location = New System.Drawing.Point(227, 10)
        Me.TxtPayDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPayDate.Name = "TxtPayDate"
        Me.TxtPayDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtPayDate.Size = New System.Drawing.Size(100, 29)
        Me.TxtPayDate.TabIndex = 0
        Me.TxtPayDate.ThisText = Nothing
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Location = New System.Drawing.Point(200, 84)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(88, 30)
        Me.BtnOk.TabIndex = 3
        Me.BtnOk.Text = "انصراف"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(294, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 30)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "ثبت"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 123)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(394, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 66
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
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(45, 24)
        Me.ToolStripStatusLabel3.Text = "F2 ثبت"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel2.Text = "F3 انصراف"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'LOne
        '
        Me.LOne.AutoSize = True
        Me.LOne.Location = New System.Drawing.Point(12, 93)
        Me.LOne.Name = "LOne"
        Me.LOne.Size = New System.Drawing.Size(0, 21)
        Me.LOne.TabIndex = 67
        Me.LOne.Visible = False
        '
        'Ledit
        '
        Me.Ledit.AutoSize = True
        Me.Ledit.Location = New System.Drawing.Point(155, 93)
        Me.Ledit.Name = "Ledit"
        Me.Ledit.Size = New System.Drawing.Size(0, 21)
        Me.Ledit.TabIndex = 68
        Me.Ledit.Visible = False
        '
        'FrmEditRasChk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 152)
        Me.Controls.Add(Me.Ledit)
        Me.Controls.Add(Me.LOne)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.Txtmon)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LDate)
        Me.Controls.Add(Me.LTime)
        Me.Controls.Add(Me.TxtPayDate)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEditRasChk"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ویرایش راس چک"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txtmon As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LDate As System.Windows.Forms.Label
    Friend WithEvents LTime As System.Windows.Forms.Label
    Friend WithEvents TxtPayDate As FarsiDate.FarsiDate
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LOne As System.Windows.Forms.Label
    Friend WithEvents Ledit As System.Windows.Forms.Label
End Class
