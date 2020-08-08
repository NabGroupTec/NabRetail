<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ActivePeopleAddEdit
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
        Me.TxtDisc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtVisitor = New System.Windows.Forms.TextBox
        Me.ChkVisitor = New System.Windows.Forms.CheckBox
        Me.TxtIdVisitor = New System.Windows.Forms.TextBox
        Me.TxtIdName = New System.Windows.Forms.TextBox
        Me.CmbState = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDate = New FarsiDate.FarsiDate
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.cmdadd = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.LIdName = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtDisc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtVisitor)
        Me.GroupBox1.Controls.Add(Me.ChkVisitor)
        Me.GroupBox1.Controls.Add(Me.TxtIdVisitor)
        Me.GroupBox1.Controls.Add(Me.TxtIdName)
        Me.GroupBox1.Controls.Add(Me.CmbState)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtDate)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(423, 102)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'TxtDisc
        '
        Me.TxtDisc.Location = New System.Drawing.Point(6, 57)
        Me.TxtDisc.Name = "TxtDisc"
        Me.TxtDisc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDisc.ShortcutsEnabled = False
        Me.TxtDisc.Size = New System.Drawing.Size(178, 29)
        Me.TxtDisc.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 21)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "شرح"
        '
        'TxtVisitor
        '
        Me.TxtVisitor.BackColor = System.Drawing.SystemColors.Window
        Me.TxtVisitor.Location = New System.Drawing.Point(6, 26)
        Me.TxtVisitor.MaxLength = 20
        Me.TxtVisitor.Name = "TxtVisitor"
        Me.TxtVisitor.ShortcutsEnabled = False
        Me.TxtVisitor.Size = New System.Drawing.Size(178, 29)
        Me.TxtVisitor.TabIndex = 2
        '
        'ChkVisitor
        '
        Me.ChkVisitor.AutoSize = True
        Me.ChkVisitor.BackColor = System.Drawing.SystemColors.Control
        Me.ChkVisitor.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ChkVisitor.Location = New System.Drawing.Point(184, 27)
        Me.ChkVisitor.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ChkVisitor.Name = "ChkVisitor"
        Me.ChkVisitor.Size = New System.Drawing.Size(63, 25)
        Me.ChkVisitor.TabIndex = 1
        Me.ChkVisitor.Text = "ویزیتور"
        Me.ChkVisitor.UseVisualStyleBackColor = False
        '
        'TxtIdVisitor
        '
        Me.TxtIdVisitor.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdVisitor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdVisitor.Location = New System.Drawing.Point(38, 26)
        Me.TxtIdVisitor.MaxLength = 20
        Me.TxtIdVisitor.Name = "TxtIdVisitor"
        Me.TxtIdVisitor.ReadOnly = True
        Me.TxtIdVisitor.ShortcutsEnabled = False
        Me.TxtIdVisitor.Size = New System.Drawing.Size(47, 29)
        Me.TxtIdVisitor.TabIndex = 72
        Me.TxtIdVisitor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtIdName
        '
        Me.TxtIdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdName.Location = New System.Drawing.Point(122, 57)
        Me.TxtIdName.Name = "TxtIdName"
        Me.TxtIdName.ReadOnly = True
        Me.TxtIdName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtIdName.ShortcutsEnabled = False
        Me.TxtIdName.Size = New System.Drawing.Size(36, 29)
        Me.TxtIdName.TabIndex = 65
        '
        'CmbState
        '
        Me.CmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbState.FormattingEnabled = True
        Me.CmbState.Items.AddRange(New Object() {"فعال", "غیر فعال"})
        Me.CmbState.Location = New System.Drawing.Point(256, 57)
        Me.CmbState.Name = "CmbState"
        Me.CmbState.Size = New System.Drawing.Size(100, 29)
        Me.CmbState.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(368, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 21)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "وضعیت"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(379, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 21)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "تاریخ"
        '
        'TxtDate
        '
        Me.TxtDate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtDate.Location = New System.Drawing.Point(256, 27)
        Me.TxtDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDate.Size = New System.Drawing.Size(100, 29)
        Me.TxtDate.TabIndex = 0
        Me.TxtDate.ThisText = Nothing
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 146)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(444, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 35
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
        'cmdadd
        '
        Me.cmdadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdadd.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdadd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdadd.Location = New System.Drawing.Point(357, 110)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(75, 30)
        Me.cmdadd.TabIndex = 5
        Me.cmdadd.Text = "ثبت"
        Me.cmdadd.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(276, 110)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 30)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "انصراف"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LIdName
        '
        Me.LIdName.AutoSize = True
        Me.LIdName.Location = New System.Drawing.Point(15, 142)
        Me.LIdName.Name = "LIdName"
        Me.LIdName.Size = New System.Drawing.Size(0, 21)
        Me.LIdName.TabIndex = 75
        Me.LIdName.Visible = False
        '
        'Frm_ActivePeopleAddEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 175)
        Me.Controls.Add(Me.LIdName)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmdadd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ActivePeopleAddEdit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "فعال سازی طرف حساب"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtIdName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDate As FarsiDate.FarsiDate
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbState As System.Windows.Forms.ComboBox
    Friend WithEvents TxtVisitor As System.Windows.Forms.TextBox
    Friend WithEvents ChkVisitor As System.Windows.Forms.CheckBox
    Friend WithEvents TxtIdVisitor As System.Windows.Forms.TextBox
    Friend WithEvents TxtDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LIdName As System.Windows.Forms.Label
End Class
