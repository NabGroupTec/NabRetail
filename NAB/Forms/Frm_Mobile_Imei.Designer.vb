<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Mobile_Imei
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LblNumberOfCurrentUser = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cln_S1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cln_S2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cln_S3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cln_S4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cln_S5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cln_S6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_S1, Me.Cln_S2, Me.Cln_S3, Me.Cln_S4, Me.Cln_S5, Me.Cln_S6})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 53)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.Size = New System.Drawing.Size(748, 396)
        Me.DataGridView1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(666, 9)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "جدید"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(570, 9)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 30)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "ویرایش"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Location = New System.Drawing.Point(474, 9)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 30)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "حذف"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'LblNumberOfCurrentUser
        '
        Me.LblNumberOfCurrentUser.AutoSize = True
        Me.LblNumberOfCurrentUser.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblNumberOfCurrentUser.ForeColor = System.Drawing.Color.Red
        Me.LblNumberOfCurrentUser.Location = New System.Drawing.Point(7, 14)
        Me.LblNumberOfCurrentUser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumberOfCurrentUser.Name = "LblNumberOfCurrentUser"
        Me.LblNumberOfCurrentUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblNumberOfCurrentUser.Size = New System.Drawing.Size(14, 21)
        Me.LblNumberOfCurrentUser.TabIndex = 6
        Me.LblNumberOfCurrentUser.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 14)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 21)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "حداکثر تعدادکاربران"
        '
        'Cln_S1
        '
        Me.Cln_S1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Cln_S1.DataPropertyName = "S1"
        Me.Cln_S1.HeaderText = "شناسه IMEI"
        Me.Cln_S1.Name = "Cln_S1"
        Me.Cln_S1.ReadOnly = True
        '
        'Cln_S2
        '
        Me.Cln_S2.DataPropertyName = "S2"
        Me.Cln_S2.HeaderText = " موجودی"
        Me.Cln_S2.Name = "Cln_S2"
        Me.Cln_S2.ReadOnly = True
        Me.Cln_S2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_S2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_S2.Width = 70
        '
        'Cln_S3
        '
        Me.Cln_S3.DataPropertyName = "S3"
        Me.Cln_S3.HeaderText = "موجودی منفی"
        Me.Cln_S3.Name = "Cln_S3"
        Me.Cln_S3.ReadOnly = True
        Me.Cln_S3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_S3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_S3.Width = 70
        '
        'Cln_S4
        '
        Me.Cln_S4.DataPropertyName = "S4"
        Me.Cln_S4.HeaderText = "تغییر قیمت "
        Me.Cln_S4.Name = "Cln_S4"
        Me.Cln_S4.ReadOnly = True
        Me.Cln_S4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_S4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_S4.Width = 70
        '
        'Cln_S5
        '
        Me.Cln_S5.DataPropertyName = "S5"
        Me.Cln_S5.HeaderText = "مشتریان فاقد اعتبار"
        Me.Cln_S5.Name = "Cln_S5"
        Me.Cln_S5.ReadOnly = True
        Me.Cln_S5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_S5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_S5.Width = 85
        '
        'Cln_S6
        '
        Me.Cln_S6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_S6.DataPropertyName = "S6"
        Me.Cln_S6.HeaderText = "گزارش فروش"
        Me.Cln_S6.Name = "Cln_S6"
        Me.Cln_S6.ReadOnly = True
        Me.Cln_S6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_S6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_S6.Width = 70
        '
        'Frm_Mobile_Imei
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 463)
        Me.Controls.Add(Me.LblNumberOfCurrentUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Mobile_Imei"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تنظیمات IMEI موبایل"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents LblNumberOfCurrentUser As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cln_S1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_S2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_S3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_S4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_S5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_S6 As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
