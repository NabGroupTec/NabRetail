<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen1
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
        Me.CRP_V = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PB = New System.Windows.Forms.ProgressBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CRP_V
        '
        Me.CRP_V.ActiveViewIndex = -1
        Me.CRP_V.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRP_V.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRP_V.DisplayStatusBar = False
        Me.CRP_V.DisplayToolbar = False
        Me.CRP_V.Location = New System.Drawing.Point(460, 169)
        Me.CRP_V.Name = "CRP_V"
        Me.CRP_V.SelectionFormula = ""
        Me.CRP_V.Size = New System.Drawing.Size(71, 57)
        Me.CRP_V.TabIndex = 0
        Me.CRP_V.ViewTimeSelectionFormula = ""
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.NAB.My.Resources.Resources.NewNab
        Me.PictureBox1.Location = New System.Drawing.Point(0, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(136, 98)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'PB
        '
        Me.PB.Location = New System.Drawing.Point(206, 158)
        Me.PB.Maximum = 14
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(74, 17)
        Me.PB.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.PB.TabIndex = 8
        Me.PB.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(207, 425)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("IRANSans", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(215, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 22)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "سیستم جامع حسابداری و پخش مویرگی"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("IRANSans", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(142, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 22)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Copyright :2015 - 2017"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("IRANSans", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(142, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 22)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Product By : Nab System"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(192, 128)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(156, 22)
        Me.LinkLabel1.TabIndex = 13
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "www.Nab-System.Com"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("IRANSans", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(142, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 22)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Visit :"
        '
        'SplashScreen1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(447, 184)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CRP_V)
        Me.Font = New System.Drawing.Font("IRANSans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nab System"
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRP_V As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PB As System.Windows.Forms.ProgressBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label4 As Label
End Class
