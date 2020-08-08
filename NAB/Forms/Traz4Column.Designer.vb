<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Traz4Column
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
        Me.ListTraz = New System.Windows.Forms.ListView
        Me.Cln_name = New System.Windows.Forms.ColumnHeader
        Me.Cln_Bed1 = New System.Windows.Forms.ColumnHeader
        Me.Cln_Bes1 = New System.Windows.Forms.ColumnHeader
        Me.Cln_Bed2 = New System.Windows.Forms.ColumnHeader
        Me.Cln_Bes2 = New System.Windows.Forms.ColumnHeader
        Me.Button1 = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListTraz
        '
        Me.ListTraz.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Cln_name, Me.Cln_Bed1, Me.Cln_Bes1, Me.Cln_Bed2, Me.Cln_Bes2})
        Me.ListTraz.FullRowSelect = True
        Me.ListTraz.GridLines = True
        Me.ListTraz.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListTraz.Location = New System.Drawing.Point(12, 30)
        Me.ListTraz.Name = "ListTraz"
        Me.ListTraz.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListTraz.RightToLeftLayout = True
        Me.ListTraz.ShowGroups = False
        Me.ListTraz.ShowItemToolTips = True
        Me.ListTraz.Size = New System.Drawing.Size(677, 455)
        Me.ListTraz.TabIndex = 1
        Me.ListTraz.UseCompatibleStateImageBehavior = False
        Me.ListTraz.View = System.Windows.Forms.View.Details
        '
        'Cln_name
        '
        Me.Cln_name.Text = "سر فصل"
        Me.Cln_name.Width = 215
        '
        'Cln_Bed1
        '
        Me.Cln_Bed1.Text = "بدهکار"
        Me.Cln_Bed1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Cln_Bed1.Width = 110
        '
        'Cln_Bes1
        '
        Me.Cln_Bes1.Text = "بستانکار"
        Me.Cln_Bes1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Cln_Bes1.Width = 110
        '
        'Cln_Bed2
        '
        Me.Cln_Bed2.Text = "بدهکار"
        Me.Cln_Bed2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Cln_Bed2.Width = 110
        '
        'Cln_Bes2
        '
        Me.Cln_Bes2.Text = "بستانکار"
        Me.Cln_Bes2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Cln_Bes2.Width = 110
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Location = New System.Drawing.Point(589, 489)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 30)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "چاپ تراز"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 525)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(703, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 42
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
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(66, 24)
        Me.ToolStripStatusLabel2.Text = "F2 چاپ تراز"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel3.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("B Traffic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(224, 26)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "مانده"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("B Traffic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(252, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 26)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "عملیات"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Traz4Column
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 554)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ListTraz)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Traz4Column"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تراز نامه"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListTraz As System.Windows.Forms.ListView
    Friend WithEvents Cln_Bed1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Cln_Bes1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Cln_Bed2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Cln_Bes2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Cln_name As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
