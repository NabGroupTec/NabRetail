<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConvertStateFactor
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
        Me.RdoNo = New System.Windows.Forms.RadioButton
        Me.RdoCur = New System.Windows.Forms.RadioButton
        Me.RdoOK = New System.Windows.Forms.RadioButton
        Me.BtnOk = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.LState = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Rdo_Visitor = New System.Windows.Forms.RadioButton
        Me.Rdo_System = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdoOK)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.RdoNo)
        Me.GroupBox1.Controls.Add(Me.RdoCur)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 1)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(369, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "تغيير وضعيت"
        '
        'RdoNo
        '
        Me.RdoNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoNo.AutoSize = True
        Me.RdoNo.Location = New System.Drawing.Point(11, 50)
        Me.RdoNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoNo.Name = "RdoNo"
        Me.RdoNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoNo.Size = New System.Drawing.Size(41, 25)
        Me.RdoNo.TabIndex = 2
        Me.RdoNo.TabStop = True
        Me.RdoNo.Text = "رد"
        Me.RdoNo.UseVisualStyleBackColor = True
        '
        'RdoCur
        '
        Me.RdoCur.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoCur.AutoSize = True
        Me.RdoCur.Location = New System.Drawing.Point(75, 48)
        Me.RdoCur.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoCur.Name = "RdoCur"
        Me.RdoCur.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoCur.Size = New System.Drawing.Size(72, 25)
        Me.RdoCur.TabIndex = 1
        Me.RdoCur.TabStop = True
        Me.RdoCur.Text = "در جریان"
        Me.RdoCur.UseVisualStyleBackColor = True
        '
        'RdoOK
        '
        Me.RdoOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RdoOK.AutoSize = True
        Me.RdoOK.Location = New System.Drawing.Point(298, 17)
        Me.RdoOK.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RdoOK.Name = "RdoOK"
        Me.RdoOK.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RdoOK.Size = New System.Drawing.Size(57, 25)
        Me.RdoOK.TabIndex = 0
        Me.RdoOK.TabStop = True
        Me.RdoOK.Text = "تایید  "
        Me.RdoOK.UseVisualStyleBackColor = True
        '
        'BtnOk
        '
        Me.BtnOk.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(295, 172)
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
        Me.Button2.Location = New System.Drawing.Point(197, 172)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 206)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(388, 29)
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
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.ComboBox1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 102)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(369, 62)
        Me.GroupBox3.TabIndex = 93
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "شرح"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"مدت تسویه زیاد", "فاقد اعتبار", "سقف اعتبار پر", "عدم تایید مدیر", "خارج از مسیر", "زمان نامناسب", "پرداخت نامناسب"})
        Me.ComboBox1.Location = New System.Drawing.Point(10, 23)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(287, 29)
        Me.ComboBox1.TabIndex = 94
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(303, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 21)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "شرح تغییر"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Rdo_System)
        Me.GroupBox2.Controls.Add(Me.Rdo_Visitor)
        Me.GroupBox2.Location = New System.Drawing.Point(173, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 76)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Rdo_Visitor
        '
        Me.Rdo_Visitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdo_Visitor.AutoSize = True
        Me.Rdo_Visitor.Location = New System.Drawing.Point(103, 32)
        Me.Rdo_Visitor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Rdo_Visitor.Name = "Rdo_Visitor"
        Me.Rdo_Visitor.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Rdo_Visitor.Size = New System.Drawing.Size(79, 25)
        Me.Rdo_Visitor.TabIndex = 4
        Me.Rdo_Visitor.TabStop = True
        Me.Rdo_Visitor.Text = "فی ویزیتور"
        Me.Rdo_Visitor.UseVisualStyleBackColor = True
        '
        'Rdo_System
        '
        Me.Rdo_System.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rdo_System.AutoSize = True
        Me.Rdo_System.Location = New System.Drawing.Point(8, 32)
        Me.Rdo_System.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Rdo_System.Name = "Rdo_System"
        Me.Rdo_System.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Rdo_System.Size = New System.Drawing.Size(79, 25)
        Me.Rdo_System.TabIndex = 5
        Me.Rdo_System.TabStop = True
        Me.Rdo_System.Text = "فی سیستم"
        Me.Rdo_System.UseVisualStyleBackColor = True
        '
        'ConvertStateFactor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 235)
        Me.Controls.Add(Me.GroupBox3)
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
        Me.Name = "ConvertStateFactor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تغییر وضعیت فاکتور"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents RdoCur As System.Windows.Forms.RadioButton
    Friend WithEvents RdoOK As System.Windows.Forms.RadioButton
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LState As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdo_Visitor As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_System As System.Windows.Forms.RadioButton
End Class
