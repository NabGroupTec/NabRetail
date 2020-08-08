<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDisc
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
        Me.TxtDisc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnCancle = New System.Windows.Forms.Button
        Me.LAdd = New System.Windows.Forms.Label
        Me.LIdChk = New System.Windows.Forms.Label
        Me.LState = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtDisc
        '
        Me.TxtDisc.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDisc.Location = New System.Drawing.Point(12, 12)
        Me.TxtDisc.MaxLength = 100
        Me.TxtDisc.Name = "TxtDisc"
        Me.TxtDisc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDisc.Size = New System.Drawing.Size(373, 29)
        Me.TxtDisc.TabIndex = 8
        Me.TxtDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(391, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 21)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "شرح"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 90)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(432, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 61
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
        Me.BtnSave.Location = New System.Drawing.Point(345, 51)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 30)
        Me.BtnSave.TabIndex = 59
        Me.BtnSave.Text = "ثبت"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnCancle
        '
        Me.BtnCancle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancle.Location = New System.Drawing.Point(264, 51)
        Me.BtnCancle.Name = "BtnCancle"
        Me.BtnCancle.Size = New System.Drawing.Size(75, 30)
        Me.BtnCancle.TabIndex = 60
        Me.BtnCancle.Text = "انصراف"
        Me.BtnCancle.UseVisualStyleBackColor = True
        '
        'LAdd
        '
        Me.LAdd.AutoSize = True
        Me.LAdd.Location = New System.Drawing.Point(76, 51)
        Me.LAdd.Name = "LAdd"
        Me.LAdd.Size = New System.Drawing.Size(0, 21)
        Me.LAdd.TabIndex = 62
        Me.LAdd.Visible = False
        '
        'LIdChk
        '
        Me.LIdChk.AutoSize = True
        Me.LIdChk.Location = New System.Drawing.Point(12, 56)
        Me.LIdChk.Name = "LIdChk"
        Me.LIdChk.Size = New System.Drawing.Size(0, 21)
        Me.LIdChk.TabIndex = 63
        Me.LIdChk.Visible = False
        '
        'LState
        '
        Me.LState.AutoSize = True
        Me.LState.Location = New System.Drawing.Point(445, 32)
        Me.LState.Name = "LState"
        Me.LState.Size = New System.Drawing.Size(0, 21)
        Me.LState.TabIndex = 64
        Me.LState.Visible = False
        '
        'FrmDisc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 119)
        Me.Controls.Add(Me.LState)
        Me.Controls.Add(Me.LIdChk)
        Me.Controls.Add(Me.LAdd)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnCancle)
        Me.Controls.Add(Me.TxtDisc)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDisc"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "شرح "
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnCancle As System.Windows.Forms.Button
    Friend WithEvents LAdd As System.Windows.Forms.Label
    Friend WithEvents LIdChk As System.Windows.Forms.Label
    Friend WithEvents LState As System.Windows.Forms.Label
End Class
