<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSanadPTP
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtDisc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDate = New FarsiDate.FarsiDate
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtMon = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtNameBes = New System.Windows.Forms.TextBox
        Me.TxtIdBes = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtNameBed = New System.Windows.Forms.TextBox
        Me.TxtIdBed = New System.Windows.Forms.TextBox
        Me.cmdadd = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.LEdit = New System.Windows.Forms.Label
        Me.LIdSanad = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtDisc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtMon)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtNameBes)
        Me.GroupBox1.Controls.Add(Me.TxtIdBes)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtNameBed)
        Me.GroupBox1.Controls.Add(Me.TxtIdBed)
        Me.GroupBox1.Location = New System.Drawing.Point(8, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(509, 135)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(447, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 21)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "توضیحات"
        '
        'TxtDisc
        '
        Me.TxtDisc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDisc.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDisc.Location = New System.Drawing.Point(6, 88)
        Me.TxtDisc.MaxLength = 200
        Me.TxtDisc.Name = "TxtDisc"
        Me.TxtDisc.Size = New System.Drawing.Size(436, 29)
        Me.TxtDisc.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 21)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "تاریخ"
        '
        'TxtDate
        '
        Me.TxtDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtDate.Location = New System.Drawing.Point(6, 58)
        Me.TxtDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDate.Size = New System.Drawing.Size(180, 29)
        Me.TxtDate.TabIndex = 4
        Me.TxtDate.ThisText = Nothing
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(445, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 21)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "مبلغ انتقال"
        '
        'TxtMon
        '
        Me.TxtMon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMon.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMon.Location = New System.Drawing.Point(262, 58)
        Me.TxtMon.MaxLength = 20
        Me.TxtMon.Name = "TxtMon"
        Me.TxtMon.ShortcutsEnabled = False
        Me.TxtMon.Size = New System.Drawing.Size(180, 29)
        Me.TxtMon.TabIndex = 3
        Me.TxtMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(192, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 21)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "بستانکار"
        '
        'TxtNameBes
        '
        Me.TxtNameBes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNameBes.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNameBes.Location = New System.Drawing.Point(6, 28)
        Me.TxtNameBes.MaxLength = 100
        Me.TxtNameBes.Name = "TxtNameBes"
        Me.TxtNameBes.ShortcutsEnabled = False
        Me.TxtNameBes.Size = New System.Drawing.Size(180, 29)
        Me.TxtNameBes.TabIndex = 2
        '
        'TxtIdBes
        '
        Me.TxtIdBes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdBes.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdBes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdBes.Location = New System.Drawing.Point(110, 28)
        Me.TxtIdBes.MaxLength = 20
        Me.TxtIdBes.Name = "TxtIdBes"
        Me.TxtIdBes.ReadOnly = True
        Me.TxtIdBes.ShortcutsEnabled = False
        Me.TxtIdBes.Size = New System.Drawing.Size(33, 29)
        Me.TxtIdBes.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(460, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 21)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "بدهکار"
        '
        'TxtNameBed
        '
        Me.TxtNameBed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNameBed.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNameBed.Location = New System.Drawing.Point(262, 28)
        Me.TxtNameBed.MaxLength = 100
        Me.TxtNameBed.Name = "TxtNameBed"
        Me.TxtNameBed.ShortcutsEnabled = False
        Me.TxtNameBed.Size = New System.Drawing.Size(180, 29)
        Me.TxtNameBed.TabIndex = 1
        '
        'TxtIdBed
        '
        Me.TxtIdBed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdBed.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdBed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdBed.Location = New System.Drawing.Point(317, 28)
        Me.TxtIdBed.MaxLength = 20
        Me.TxtIdBed.Name = "TxtIdBed"
        Me.TxtIdBed.ReadOnly = True
        Me.TxtIdBed.ShortcutsEnabled = False
        Me.TxtIdBed.Size = New System.Drawing.Size(33, 29)
        Me.TxtIdBed.TabIndex = 61
        '
        'cmdadd
        '
        Me.cmdadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdadd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdadd.Location = New System.Drawing.Point(432, 140)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(75, 30)
        Me.cmdadd.TabIndex = 6
        Me.cmdadd.Text = "ثبت"
        Me.cmdadd.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancel.Location = New System.Drawing.Point(351, 140)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 30)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "انصراف"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 178)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(525, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 53
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
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(60, 24)
        Me.ToolStripStatusLabel4.Text = "F3 انصراف"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'LEdit
        '
        Me.LEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LEdit.AutoSize = True
        Me.LEdit.Location = New System.Drawing.Point(170, 145)
        Me.LEdit.Name = "LEdit"
        Me.LEdit.Size = New System.Drawing.Size(0, 21)
        Me.LEdit.TabIndex = 71
        Me.LEdit.Visible = False
        '
        'LIdSanad
        '
        Me.LIdSanad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LIdSanad.AutoSize = True
        Me.LIdSanad.Location = New System.Drawing.Point(233, 145)
        Me.LIdSanad.Name = "LIdSanad"
        Me.LIdSanad.Size = New System.Drawing.Size(0, 21)
        Me.LIdSanad.TabIndex = 72
        Me.LIdSanad.Visible = False
        '
        'FrmSanadPTP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 207)
        Me.Controls.Add(Me.LIdSanad)
        Me.Controls.Add(Me.LEdit)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.cmdadd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSanadPTP"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "طرف حساب به طرف حساب"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNameBed As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdBed As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNameBes As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdBes As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMon As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDate As FarsiDate.FarsiDate
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LEdit As System.Windows.Forms.Label
    Friend WithEvents LIdSanad As System.Windows.Forms.Label
End Class
