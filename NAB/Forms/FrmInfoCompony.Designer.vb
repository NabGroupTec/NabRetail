<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfoCompony
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
        Me.ChkAdmin = New System.Windows.Forms.CheckBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.PicArm = New System.Windows.Forms.PictureBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TxtPath = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtFooter = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtAddress = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtTell = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtAdd = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtHeader = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Btnadd = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.LId = New System.Windows.Forms.Label
        Me.FD = New System.Windows.Forms.FolderBrowserDialog
        Me.OpenF = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicArm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkAdmin)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.PicArm)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.TxtPath)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtFooter)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtAddress)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtTell)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtAdd)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtHeader)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(466, 295)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "مشخصات"
        '
        'ChkAdmin
        '
        Me.ChkAdmin.AutoSize = True
        Me.ChkAdmin.Location = New System.Drawing.Point(250, 262)
        Me.ChkAdmin.Name = "ChkAdmin"
        Me.ChkAdmin.Size = New System.Drawing.Size(204, 25)
        Me.ChkAdmin.TabIndex = 110
        Me.ChkAdmin.Text = "ویرایش  مشخصات برای تمام کاربران"
        Me.ChkAdmin.UseVisualStyleBackColor = True
        Me.ChkAdmin.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(361, 215)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 21)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "تصویر آرم شرکت"
        '
        'PicArm
        '
        Me.PicArm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicArm.Location = New System.Drawing.Point(7, 213)
        Me.PicArm.Name = "PicArm"
        Me.PicArm.Size = New System.Drawing.Size(99, 74)
        Me.PicArm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicArm.TabIndex = 38
        Me.PicArm.TabStop = False
        '
        'Button3
        '
        'Me.Button3.BackgroundImage = Global.NAB.My.Resources.Add
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Location = New System.Drawing.Point(273, 210)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(35, 30)
        Me.Button3.TabIndex = 7
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        ' Me.Button4.BackgroundImage = Global.NAB.My.Resources.Resources.Delete
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Location = New System.Drawing.Point(309, 210)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(35, 30)
        Me.Button4.TabIndex = 8
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button2.Location = New System.Drawing.Point(309, 181)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 30)
        Me.Button2.TabIndex = 110
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtPath
        '
        Me.TxtPath.BackColor = System.Drawing.Color.White
        Me.TxtPath.Location = New System.Drawing.Point(7, 181)
        Me.TxtPath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtPath.MaxLength = 200
        Me.TxtPath.Name = "TxtPath"
        Me.TxtPath.ReadOnly = True
        Me.TxtPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtPath.Size = New System.Drawing.Size(302, 29)
        Me.TxtPath.TabIndex = 109
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(354, 186)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 21)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "محل نسخه پشتیبان"
        '
        'TxtFooter
        '
        Me.TxtFooter.BackColor = System.Drawing.Color.White
        Me.TxtFooter.Location = New System.Drawing.Point(7, 151)
        Me.TxtFooter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtFooter.MaxLength = 200
        Me.TxtFooter.Name = "TxtFooter"
        Me.TxtFooter.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtFooter.Size = New System.Drawing.Size(337, 29)
        Me.TxtFooter.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(351, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 21)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "تبلیغات پایین فاکتور"
        '
        'TxtAddress
        '
        Me.TxtAddress.BackColor = System.Drawing.Color.White
        Me.TxtAddress.Location = New System.Drawing.Point(7, 91)
        Me.TxtAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtAddress.MaxLength = 200
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAddress.Size = New System.Drawing.Size(337, 29)
        Me.TxtAddress.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(415, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 21)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "آدرس"
        '
        'TxtTell
        '
        Me.TxtTell.BackColor = System.Drawing.Color.White
        Me.TxtTell.Location = New System.Drawing.Point(7, 61)
        Me.TxtTell.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtTell.MaxLength = 200
        Me.TxtTell.Name = "TxtTell"
        Me.TxtTell.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTell.Size = New System.Drawing.Size(187, 29)
        Me.TxtTell.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(201, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 21)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "تلفن/فکس"
        '
        'TxtAdd
        '
        Me.TxtAdd.BackColor = System.Drawing.Color.White
        Me.TxtAdd.Location = New System.Drawing.Point(270, 61)
        Me.TxtAdd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtAdd.MaxLength = 200
        Me.TxtAdd.Name = "TxtAdd"
        Me.TxtAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAdd.Size = New System.Drawing.Size(74, 29)
        Me.TxtAdd.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(394, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 21)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "شماره ثبت"
        '
        'TxtName
        '
        Me.TxtName.BackColor = System.Drawing.Color.White
        Me.TxtName.Location = New System.Drawing.Point(7, 30)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtName.MaxLength = 200
        Me.TxtName.Name = "TxtName"
        Me.TxtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtName.Size = New System.Drawing.Size(337, 29)
        Me.TxtName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(397, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 21)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "نام شرکت"
        '
        'TxtHeader
        '
        Me.TxtHeader.BackColor = System.Drawing.Color.White
        Me.TxtHeader.Location = New System.Drawing.Point(7, 121)
        Me.TxtHeader.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtHeader.MaxLength = 200
        Me.TxtHeader.Name = "TxtHeader"
        Me.TxtHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtHeader.Size = New System.Drawing.Size(337, 29)
        Me.TxtHeader.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(383, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 21)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "تبلیغات عنوان"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Location = New System.Drawing.Point(294, 315)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 30)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "انصراف"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Btnadd
        '
        Me.Btnadd.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Btnadd.Location = New System.Drawing.Point(390, 315)
        Me.Btnadd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Btnadd.Name = "Btnadd"
        Me.Btnadd.Size = New System.Drawing.Size(88, 30)
        Me.Btnadd.TabIndex = 6
        Me.Btnadd.Text = "ذخیره"
        Me.Btnadd.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 354)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(492, 29)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(55, 24)
        Me.ToolStripStatusLabel2.Text = "F2 ذخیره"
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
        'LId
        '
        Me.LId.AutoSize = True
        Me.LId.Location = New System.Drawing.Point(145, 225)
        Me.LId.Name = "LId"
        Me.LId.Size = New System.Drawing.Size(0, 21)
        Me.LId.TabIndex = 109
        Me.LId.Visible = False
        '
        'OpenF
        '
        Me.OpenF.Filter = "JPG(*.JPG)|*.JPG|PNG(*.PNG)|*.PNG|BMP(*.BMP)|*.BMP|All Image Support(*.JPG;*.PNG;" & _
            "*.BMP)|*.JPG;*.PNG;*.BMP"
        Me.OpenF.Title = "انتخاب عکس آرم شرکت"
        '
        'FrmInfoCompony
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 383)
        Me.Controls.Add(Me.LId)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Btnadd)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfoCompony"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مشخصات شرکت"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicArm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtHeader As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Btnadd As System.Windows.Forms.Button
    Friend WithEvents TxtFooter As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtTell As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LId As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtPath As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents PicArm As System.Windows.Forms.PictureBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents OpenF As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ChkAdmin As System.Windows.Forms.CheckBox
End Class
