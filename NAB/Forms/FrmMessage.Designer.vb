<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMessage
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
        Me.TxtMessage = New System.Windows.Forms.TextBox
        Me.TxtUser = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtVisitor = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtIdVisitor = New System.Windows.Forms.TextBox
        Me.TxtIdUser = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtDateSend = New FarsiDate.FarsiDate
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDateRecive = New FarsiDate.FarsiDate
        Me.ChkResponse = New System.Windows.Forms.CheckBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolSend = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolCancel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtSubject = New System.Windows.Forms.TextBox
        Me.TxtResponse = New System.Windows.Forms.TextBox
        Me.ChkNum = New System.Windows.Forms.CheckBox
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtMessage
        '
        Me.TxtMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMessage.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMessage.Location = New System.Drawing.Point(10, 156)
        Me.TxtMessage.Multiline = True
        Me.TxtMessage.Name = "TxtMessage"
        Me.TxtMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtMessage.Size = New System.Drawing.Size(417, 303)
        Me.TxtMessage.TabIndex = 10
        '
        'TxtUser
        '
        Me.TxtUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUser.BackColor = System.Drawing.SystemColors.Window
        Me.TxtUser.Location = New System.Drawing.Point(52, 65)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Size = New System.Drawing.Size(287, 29)
        Me.TxtUser.TabIndex = 5
        Me.TxtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(351, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(80, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "گیرنده (کاربر)"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(342, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(89, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "گیرنده (ویزیتور)"
        '
        'TxtVisitor
        '
        Me.TxtVisitor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtVisitor.BackColor = System.Drawing.SystemColors.Window
        Me.TxtVisitor.Location = New System.Drawing.Point(52, 95)
        Me.TxtVisitor.Name = "TxtVisitor"
        Me.TxtVisitor.Size = New System.Drawing.Size(287, 29)
        Me.TxtVisitor.TabIndex = 7
        Me.TxtVisitor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(10, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(42, 29)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtIdVisitor
        '
        Me.TxtIdVisitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdVisitor.Location = New System.Drawing.Point(167, 95)
        Me.TxtIdVisitor.Name = "TxtIdVisitor"
        Me.TxtIdVisitor.Size = New System.Drawing.Size(51, 29)
        Me.TxtIdVisitor.TabIndex = 79
        '
        'TxtIdUser
        '
        Me.TxtIdUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdUser.Location = New System.Drawing.Point(219, 65)
        Me.TxtIdUser.Name = "TxtIdUser"
        Me.TxtIdUser.Size = New System.Drawing.Size(49, 29)
        Me.TxtIdUser.TabIndex = 80
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(10, 94)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(42, 29)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(362, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 21)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "تاریخ ارسال"
        '
        'TxtDateSend
        '
        Me.TxtDateSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDateSend.Enabled = False
        Me.TxtDateSend.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtDateSend.Location = New System.Drawing.Point(246, 5)
        Me.TxtDateSend.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtDateSend.Name = "TxtDateSend"
        Me.TxtDateSend.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDateSend.Size = New System.Drawing.Size(93, 29)
        Me.TxtDateSend.TabIndex = 0
        Me.TxtDateSend.ThisText = Nothing
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(152, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 21)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "تاریخ دریافت"
        '
        'TxtDateRecive
        '
        Me.TxtDateRecive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDateRecive.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtDateRecive.Location = New System.Drawing.Point(52, 5)
        Me.TxtDateRecive.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtDateRecive.Name = "TxtDateRecive"
        Me.TxtDateRecive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDateRecive.Size = New System.Drawing.Size(93, 29)
        Me.TxtDateRecive.TabIndex = 1
        Me.TxtDateRecive.ThisText = Nothing
        '
        'ChkResponse
        '
        Me.ChkResponse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkResponse.AutoSize = True
        Me.ChkResponse.Location = New System.Drawing.Point(17, 37)
        Me.ChkResponse.Name = "ChkResponse"
        Me.ChkResponse.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkResponse.Size = New System.Drawing.Size(211, 25)
        Me.ChkResponse.TabIndex = 4
        Me.ChkResponse.Text = "قابلیت پاسخگویی به این پیام فعال شود"
        Me.ChkResponse.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolSend, Me.ToolCancel, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 497)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(435, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 85
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolSend
        '
        Me.ToolSend.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolSend.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolSend.Name = "ToolSend"
        Me.ToolSend.Size = New System.Drawing.Size(53, 24)
        Me.ToolSend.Text = "F2 ارسال"
        '
        'ToolCancel
        '
        Me.ToolCancel.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolCancel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolCancel.Name = "ToolCancel"
        Me.ToolCancel.Size = New System.Drawing.Size(60, 24)
        Me.ToolCancel.Text = "F3 انصراف"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Location = New System.Drawing.Point(342, 465)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(85, 29)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "ارسال"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Location = New System.Drawing.Point(251, 465)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(85, 29)
        Me.Button6.TabIndex = 12
        Me.Button6.Text = "انصراف"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(375, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(56, 21)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "عنوان پیام"
        '
        'TxtSubject
        '
        Me.TxtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubject.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSubject.Location = New System.Drawing.Point(10, 125)
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(329, 29)
        Me.TxtSubject.TabIndex = 9
        Me.TxtSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtResponse
        '
        Me.TxtResponse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtResponse.BackColor = System.Drawing.SystemColors.Window
        Me.TxtResponse.Enabled = False
        Me.TxtResponse.Location = New System.Drawing.Point(246, 35)
        Me.TxtResponse.Name = "TxtResponse"
        Me.TxtResponse.Size = New System.Drawing.Size(93, 29)
        Me.TxtResponse.TabIndex = 3
        Me.TxtResponse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChkNum
        '
        Me.ChkNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkNum.AutoSize = True
        Me.ChkNum.Location = New System.Drawing.Point(351, 37)
        Me.ChkNum.Name = "ChkNum"
        Me.ChkNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkNum.Size = New System.Drawing.Size(76, 25)
        Me.ChkNum.TabIndex = 2
        Me.ChkNum.Text = "پیوست به"
        Me.ChkNum.UseVisualStyleBackColor = True
        '
        'FrmMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 526)
        Me.Controls.Add(Me.ChkNum)
        Me.Controls.Add(Me.TxtResponse)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TxtMessage)
        Me.Controls.Add(Me.ChkResponse)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtDateRecive)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtDateSend)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtVisitor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtUser)
        Me.Controls.Add(Me.TxtIdVisitor)
        Me.Controls.Add(Me.TxtIdUser)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmMessage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مشخصات پیام"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtMessage As System.Windows.Forms.TextBox
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtVisitor As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtIdVisitor As System.Windows.Forms.TextBox
    Friend WithEvents TxtIdUser As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDateSend As FarsiDate.FarsiDate
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDateRecive As FarsiDate.FarsiDate
    Friend WithEvents ChkResponse As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolSend As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolCancel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtSubject As System.Windows.Forms.TextBox
    Friend WithEvents TxtResponse As System.Windows.Forms.TextBox
    Friend WithEvents ChkNum As System.Windows.Forms.CheckBox
End Class
