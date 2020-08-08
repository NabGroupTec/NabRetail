<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConvertStateGet
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
        Me.RdoBrat = New System.Windows.Forms.RadioButton
        Me.RdoVosol = New System.Windows.Forms.RadioButton
        Me.RdoBargasht = New System.Windows.Forms.RadioButton
        Me.RdoDarVosol = New System.Windows.Forms.RadioButton
        Me.BtnOk = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.LState = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.FarsiDateBrat = New FarsiDate.FarsiDate
        Me.LdateBrat = New System.Windows.Forms.Label
        Me.TxtBratBank = New System.Windows.Forms.TextBox
        Me.LBrat = New System.Windows.Forms.Label
        Me.TxtBratID = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TxtDisc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.DateChk = New FarsiDate.FarsiDate
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdoBrat)
        Me.GroupBox1.Controls.Add(Me.RdoVosol)
        Me.GroupBox1.Controls.Add(Me.RdoBargasht)
        Me.GroupBox1.Controls.Add(Me.RdoDarVosol)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(287, 92)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "تغيير وضعيت"
        '
        'RdoBrat
        '
        Me.RdoBrat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoBrat.AutoSize = True
        Me.RdoBrat.Location = New System.Drawing.Point(30, 56)
        Me.RdoBrat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoBrat.Name = "RdoBrat"
        Me.RdoBrat.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoBrat.Size = New System.Drawing.Size(52, 25)
        Me.RdoBrat.TabIndex = 3
        Me.RdoBrat.TabStop = True
        Me.RdoBrat.Text = "برات"
        Me.RdoBrat.UseVisualStyleBackColor = True
        '
        'RdoVosol
        '
        Me.RdoVosol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoVosol.AutoSize = True
        Me.RdoVosol.Location = New System.Drawing.Point(197, 56)
        Me.RdoVosol.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoVosol.Name = "RdoVosol"
        Me.RdoVosol.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoVosol.Size = New System.Drawing.Size(81, 25)
        Me.RdoVosol.TabIndex = 2
        Me.RdoVosol.TabStop = True
        Me.RdoVosol.Text = "وصول شده"
        Me.RdoVosol.UseVisualStyleBackColor = True
        '
        'RdoBargasht
        '
        Me.RdoBargasht.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoBargasht.AutoSize = True
        Me.RdoBargasht.Location = New System.Drawing.Point(16, 21)
        Me.RdoBargasht.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoBargasht.Name = "RdoBargasht"
        Me.RdoBargasht.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoBargasht.Size = New System.Drawing.Size(66, 25)
        Me.RdoBargasht.TabIndex = 1
        Me.RdoBargasht.TabStop = True
        Me.RdoBargasht.Text = "برگشتی"
        Me.RdoBargasht.UseVisualStyleBackColor = True
        '
        'RdoDarVosol
        '
        Me.RdoDarVosol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoDarVosol.AutoSize = True
        Me.RdoDarVosol.Location = New System.Drawing.Point(176, 21)
        Me.RdoDarVosol.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoDarVosol.Name = "RdoDarVosol"
        Me.RdoDarVosol.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoDarVosol.Size = New System.Drawing.Size(102, 25)
        Me.RdoDarVosol.TabIndex = 0
        Me.RdoDarVosol.TabStop = True
        Me.RdoDarVosol.Text = "در جريان وصول"
        Me.RdoDarVosol.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(212, 261)
        Me.BtnOk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(88, 30)
        Me.BtnOk.TabIndex = 7
        Me.BtnOk.Text = "تاييد"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button2.Location = New System.Drawing.Point(114, 261)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 30)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "انصراف"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'LState
        '
        Me.LState.AutoSize = True
        Me.LState.Location = New System.Drawing.Point(324, 29)
        Me.LState.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LState.Name = "LState"
        Me.LState.Size = New System.Drawing.Size(0, 21)
        Me.LState.TabIndex = 90
        Me.LState.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 295)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(311, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 91
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(47, 24)
        Me.ToolStripStatusLabel2.Text = "F2 تایید"
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
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.FarsiDateBrat)
        Me.GroupBox2.Controls.Add(Me.LdateBrat)
        Me.GroupBox2.Controls.Add(Me.TxtBratBank)
        Me.GroupBox2.Controls.Add(Me.LBrat)
        Me.GroupBox2.Controls.Add(Me.TxtBratID)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 194)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(287, 62)
        Me.GroupBox2.TabIndex = 92
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ویژه برات"
        '
        'FarsiDateBrat
        '
        Me.FarsiDateBrat.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FarsiDateBrat.Location = New System.Drawing.Point(7, 22)
        Me.FarsiDateBrat.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.FarsiDateBrat.Name = "FarsiDateBrat"
        Me.FarsiDateBrat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FarsiDateBrat.Size = New System.Drawing.Size(75, 29)
        Me.FarsiDateBrat.TabIndex = 6
        Me.FarsiDateBrat.ThisText = Nothing
        '
        'LdateBrat
        '
        Me.LdateBrat.AutoSize = True
        Me.LdateBrat.Location = New System.Drawing.Point(82, 25)
        Me.LdateBrat.Name = "LdateBrat"
        Me.LdateBrat.Size = New System.Drawing.Size(35, 21)
        Me.LdateBrat.TabIndex = 42
        Me.LdateBrat.Text = "تاریخ"
        '
        'TxtBratBank
        '
        Me.TxtBratBank.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBratBank.Location = New System.Drawing.Point(123, 23)
        Me.TxtBratBank.MaxLength = 20
        Me.TxtBratBank.Name = "TxtBratBank"
        Me.TxtBratBank.ShortcutsEnabled = False
        Me.TxtBratBank.Size = New System.Drawing.Size(86, 29)
        Me.TxtBratBank.TabIndex = 5
        Me.TxtBratBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LBrat
        '
        Me.LBrat.AutoSize = True
        Me.LBrat.Location = New System.Drawing.Point(209, 26)
        Me.LBrat.Name = "LBrat"
        Me.LBrat.Size = New System.Drawing.Size(73, 21)
        Me.LBrat.TabIndex = 39
        Me.LBrat.Text = "برات به بانک"
        '
        'TxtBratID
        '
        Me.TxtBratID.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBratID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBratID.Location = New System.Drawing.Point(123, 23)
        Me.TxtBratID.MaxLength = 20
        Me.TxtBratID.Name = "TxtBratID"
        Me.TxtBratID.ReadOnly = True
        Me.TxtBratID.Size = New System.Drawing.Size(81, 22)
        Me.TxtBratID.TabIndex = 43
        Me.TxtBratID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.DateChk)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.TxtDisc)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(287, 92)
        Me.GroupBox3.TabIndex = 93
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "شرح"
        '
        'TxtDisc
        '
        Me.TxtDisc.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDisc.Location = New System.Drawing.Point(11, 23)
        Me.TxtDisc.MaxLength = 200
        Me.TxtDisc.Name = "TxtDisc"
        Me.TxtDisc.ShortcutsEnabled = False
        Me.TxtDisc.Size = New System.Drawing.Size(202, 29)
        Me.TxtDisc.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 21)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "شرح سند"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(123, 23)
        Me.TextBox2.MaxLength = 20
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(81, 22)
        Me.TextBox2.TabIndex = 43
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateChk
        '
        Me.DateChk.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateChk.Location = New System.Drawing.Point(123, 53)
        Me.DateChk.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DateChk.Name = "DateChk"
        Me.DateChk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DateChk.Size = New System.Drawing.Size(90, 29)
        Me.DateChk.TabIndex = 44
        Me.DateChk.ThisText = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(220, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 21)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "تاریخ سند"
        '
        'ConvertStateGet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 324)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.LState)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConvertStateGet"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تغییر وضعیت چک"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoVosol As System.Windows.Forms.RadioButton
    Friend WithEvents RdoBargasht As System.Windows.Forms.RadioButton
    Friend WithEvents RdoDarVosol As System.Windows.Forms.RadioButton
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents RdoBrat As System.Windows.Forms.RadioButton
    Friend WithEvents LState As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents FarsiDateBrat As FarsiDate.FarsiDate
    Friend WithEvents LdateBrat As System.Windows.Forms.Label
    Friend WithEvents TxtBratBank As System.Windows.Forms.TextBox
    Friend WithEvents LBrat As System.Windows.Forms.Label
    Friend WithEvents TxtBratID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents DateChk As FarsiDate.FarsiDate
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
