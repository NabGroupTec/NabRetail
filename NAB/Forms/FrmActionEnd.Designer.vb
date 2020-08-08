<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActionEnd
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
        Me.PicDatabase = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PicDefine = New System.Windows.Forms.PictureBox
        Me.LNam = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PMKala = New System.Windows.Forms.ProgressBar
        Me.Label6 = New System.Windows.Forms.Label
        Me.PicMKala = New System.Windows.Forms.PictureBox
        Me.PR = New System.Windows.Forms.ProgressBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.PicR = New System.Windows.Forms.PictureBox
        Me.PKala = New System.Windows.Forms.ProgressBar
        Me.Label4 = New System.Windows.Forms.Label
        Me.PicKala = New System.Windows.Forms.PictureBox
        Me.PDefine = New System.Windows.Forms.ProgressBar
        Me.PDatabase = New System.Windows.Forms.ProgressBar
        Me.PBackUp = New System.Windows.Forms.ProgressBar
        Me.PicBackUp = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnSave = New System.Windows.Forms.Button
        Me.PChk = New System.Windows.Forms.ProgressBar
        Me.Label7 = New System.Windows.Forms.Label
        Me.PicChk = New System.Windows.Forms.PictureBox
        CType(Me.PicDatabase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicDefine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicMKala, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicKala, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicBackUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicChk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicDatabase
        '
        Me.PicDatabase.Location = New System.Drawing.Point(260, 56)
        Me.PicDatabase.Name = "PicDatabase"
        Me.PicDatabase.Size = New System.Drawing.Size(30, 25)
        Me.PicDatabase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicDatabase.TabIndex = 10
        Me.PicDatabase.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(163, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 21)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "ساخت دوره مالی"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(187, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 21)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "تعاریف اولیه"
        '
        'PicDefine
        '
        Me.PicDefine.Location = New System.Drawing.Point(260, 87)
        Me.PicDefine.Name = "PicDefine"
        Me.PicDefine.Size = New System.Drawing.Size(30, 25)
        Me.PicDefine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicDefine.TabIndex = 12
        Me.PicDefine.TabStop = False
        '
        'LNam
        '
        Me.LNam.AutoSize = True
        Me.LNam.Location = New System.Drawing.Point(479, 12)
        Me.LNam.Name = "LNam"
        Me.LNam.Size = New System.Drawing.Size(0, 21)
        Me.LNam.TabIndex = 16
        Me.LNam.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PChk)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.PicChk)
        Me.GroupBox1.Controls.Add(Me.PMKala)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.PicMKala)
        Me.GroupBox1.Controls.Add(Me.PR)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.PicR)
        Me.GroupBox1.Controls.Add(Me.PKala)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PicKala)
        Me.GroupBox1.Controls.Add(Me.PDefine)
        Me.GroupBox1.Controls.Add(Me.PDatabase)
        Me.GroupBox1.Controls.Add(Me.PBackUp)
        Me.GroupBox1.Controls.Add(Me.PicBackUp)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PicDatabase)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PicDefine)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(305, 240)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "لیست عملیات"
        '
        'PMKala
        '
        Me.PMKala.Location = New System.Drawing.Point(15, 174)
        Me.PMKala.Name = "PMKala"
        Me.PMKala.Size = New System.Drawing.Size(133, 23)
        Me.PMKala.TabIndex = 30
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(163, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 21)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "موجودی اولیه کالا"
        '
        'PicMKala
        '
        Me.PicMKala.Location = New System.Drawing.Point(260, 174)
        Me.PicMKala.Name = "PicMKala"
        Me.PicMKala.Size = New System.Drawing.Size(30, 25)
        Me.PicMKala.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicMKala.TabIndex = 28
        Me.PicMKala.TabStop = False
        '
        'PR
        '
        Me.PR.Location = New System.Drawing.Point(15, 145)
        Me.PR.Name = "PR"
        Me.PR.Size = New System.Drawing.Size(133, 23)
        Me.PR.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(218, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 21)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "روابط"
        '
        'PicR
        '
        Me.PicR.Location = New System.Drawing.Point(260, 145)
        Me.PicR.Name = "PicR"
        Me.PicR.Size = New System.Drawing.Size(30, 25)
        Me.PicR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicR.TabIndex = 25
        Me.PicR.TabStop = False
        '
        'PKala
        '
        Me.PKala.Location = New System.Drawing.Point(15, 116)
        Me.PKala.Name = "PKala"
        Me.PKala.Size = New System.Drawing.Size(133, 23)
        Me.PKala.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(228, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 21)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "کالا"
        '
        'PicKala
        '
        Me.PicKala.Location = New System.Drawing.Point(260, 116)
        Me.PicKala.Name = "PicKala"
        Me.PicKala.Size = New System.Drawing.Size(30, 25)
        Me.PicKala.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicKala.TabIndex = 22
        Me.PicKala.TabStop = False
        '
        'PDefine
        '
        Me.PDefine.Location = New System.Drawing.Point(15, 87)
        Me.PDefine.Name = "PDefine"
        Me.PDefine.Size = New System.Drawing.Size(133, 23)
        Me.PDefine.TabIndex = 21
        '
        'PDatabase
        '
        Me.PDatabase.Location = New System.Drawing.Point(15, 56)
        Me.PDatabase.Name = "PDatabase"
        Me.PDatabase.Size = New System.Drawing.Size(133, 23)
        Me.PDatabase.TabIndex = 20
        '
        'PBackUp
        '
        Me.PBackUp.Location = New System.Drawing.Point(15, 25)
        Me.PBackUp.Name = "PBackUp"
        Me.PBackUp.Size = New System.Drawing.Size(133, 23)
        Me.PBackUp.TabIndex = 19
        '
        'PicBackUp
        '
        Me.PicBackUp.Location = New System.Drawing.Point(260, 25)
        Me.PicBackUp.Name = "PicBackUp"
        Me.PicBackUp.Size = New System.Drawing.Size(30, 25)
        Me.PicBackUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBackUp.TabIndex = 14
        Me.PicBackUp.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(154, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 21)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "تهیه نسخه پشتیبان"
        '
        'BtnSave
        '
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.Location = New System.Drawing.Point(382, 12)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(108, 33)
        Me.BtnSave.TabIndex = 18
        Me.BtnSave.Text = "بستن دوره مالی"
        Me.BtnSave.UseVisualStyleBackColor = True
        Me.BtnSave.Visible = False
        '
        'PChk
        '
        Me.PChk.Location = New System.Drawing.Point(15, 203)
        Me.PChk.Name = "PChk"
        Me.PChk.Size = New System.Drawing.Size(133, 23)
        Me.PChk.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(154, 205)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 21)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "موجودی اولیه اسناد"
        '
        'PicChk
        '
        Me.PicChk.Location = New System.Drawing.Point(260, 203)
        Me.PicChk.Name = "PicChk"
        Me.PicChk.Size = New System.Drawing.Size(30, 25)
        Me.PicChk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicChk.TabIndex = 31
        Me.PicChk.TabStop = False
        '
        'FrmActionEnd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(317, 252)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LNam)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmActionEnd"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "عملیات بستن دوره مالی"
        CType(Me.PicDatabase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicDefine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PicMKala, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicKala, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicBackUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicChk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicDatabase As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PicDefine As System.Windows.Forms.PictureBox
    Friend WithEvents LNam As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PicBackUp As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents PDefine As System.Windows.Forms.ProgressBar
    Friend WithEvents PDatabase As System.Windows.Forms.ProgressBar
    Friend WithEvents PBackUp As System.Windows.Forms.ProgressBar
    Friend WithEvents PKala As System.Windows.Forms.ProgressBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PicKala As System.Windows.Forms.PictureBox
    Friend WithEvents PR As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PicR As System.Windows.Forms.PictureBox
    Friend WithEvents PMKala As System.Windows.Forms.ProgressBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PicMKala As System.Windows.Forms.PictureBox
    Friend WithEvents PChk As System.Windows.Forms.ProgressBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PicChk As System.Windows.Forms.PictureBox
End Class
