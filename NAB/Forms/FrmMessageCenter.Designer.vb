<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMessageCenter
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("پیام های دریافتی")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("پیام های ارسالی")
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.ListV = New System.Windows.Forms.ListView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolEdit = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolNew = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.BtnDell = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.Cln_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Dat = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Sender = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Reciver = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Subject = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Read = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cln_RDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sender_IdUser = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Sender_IdVisitor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reciver_IdUser = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reciver_IdVisitor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cln_Message = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RChk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Response = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cln_Id, Me.Cln_Dat, Me.Cln_Sender, Me.Cln_Reciver, Me.Cln_Subject, Me.Cln_Read, Me.Cln_RDate, Me.Sender_IdUser, Me.Sender_IdVisitor, Me.Reciver_IdUser, Me.Reciver_IdVisitor, Me.Cln_Message, Me.RChk, Me.Response})
        Me.DGV1.Location = New System.Drawing.Point(8, 24)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV1.Size = New System.Drawing.Size(700, 366)
        Me.DGV1.TabIndex = 0
        '
        'ListV
        '
        Me.ListV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListV.HideSelection = False
        Me.ListV.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
        Me.ListV.Location = New System.Drawing.Point(731, 18)
        Me.ListV.Name = "ListV"
        Me.ListV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListV.RightToLeftLayout = True
        Me.ListV.Size = New System.Drawing.Size(98, 417)
        Me.ListV.TabIndex = 1
        Me.ListV.UseCompatibleStateImageBehavior = False
        Me.ListV.View = System.Windows.Forms.View.List
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolEdit, Me.ToolStripStatusLabel5, Me.ToolNew, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 446)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(841, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 65
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolEdit
        '
        Me.ToolEdit.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolEdit.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(55, 24)
        Me.ToolEdit.Text = "F2 نمایش"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(52, 24)
        Me.ToolStripStatusLabel5.Text = "F3 حذف"
        '
        'ToolNew
        '
        Me.ToolNew.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolNew.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(52, 24)
        Me.ToolNew.Text = "F4 جدید"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(63, 24)
        Me.ToolStripStatusLabel2.Text = "F5 بازخوانی"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(152, 24)
        Me.ToolStripStatusLabel4.Text = "رنگ خاکستری : پیام خوانده نشده"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.BtnDell)
        Me.GroupBox1.Controls.Add(Me.BtnNew)
        Me.GroupBox1.Controls.Add(Me.DGV1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(713, 431)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "مشخصات پیام"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(622, 396)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 29)
        Me.Button1.TabIndex = 90
        Me.Button1.Text = "ویرایش"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnDell
        '
        Me.BtnDell.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDell.Location = New System.Drawing.Point(531, 396)
        Me.BtnDell.Name = "BtnDell"
        Me.BtnDell.Size = New System.Drawing.Size(85, 29)
        Me.BtnDell.TabIndex = 88
        Me.BtnDell.Text = "حذف"
        Me.BtnDell.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNew.Location = New System.Drawing.Point(440, 396)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(85, 29)
        Me.BtnNew.TabIndex = 87
        Me.BtnNew.Text = "جدید"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'Cln_Id
        '
        Me.Cln_Id.DataPropertyName = "Id"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Id.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cln_Id.HeaderText = "شماره"
        Me.Cln_Id.Name = "Cln_Id"
        Me.Cln_Id.ReadOnly = True
        Me.Cln_Id.Width = 50
        '
        'Cln_Dat
        '
        Me.Cln_Dat.DataPropertyName = "C_Date"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cln_Dat.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cln_Dat.HeaderText = "تاریخ"
        Me.Cln_Dat.Name = "Cln_Dat"
        Me.Cln_Dat.ReadOnly = True
        Me.Cln_Dat.Width = 75
        '
        'Cln_Sender
        '
        Me.Cln_Sender.DataPropertyName = "Sender_Nam"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Sender.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cln_Sender.HeaderText = "فرستنده"
        Me.Cln_Sender.Name = "Cln_Sender"
        Me.Cln_Sender.ReadOnly = True
        Me.Cln_Sender.Width = 130
        '
        'Cln_Reciver
        '
        Me.Cln_Reciver.DataPropertyName = "Reciver_Nam"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Cln_Reciver.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cln_Reciver.HeaderText = "گیرنده"
        Me.Cln_Reciver.Name = "Cln_Reciver"
        Me.Cln_Reciver.ReadOnly = True
        Me.Cln_Reciver.Width = 130
        '
        'Cln_Subject
        '
        Me.Cln_Subject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Cln_Subject.DataPropertyName = "Subject"
        Me.Cln_Subject.HeaderText = "عنوان"
        Me.Cln_Subject.Name = "Cln_Subject"
        Me.Cln_Subject.ReadOnly = True
        Me.Cln_Subject.Width = 269
        '
        'Cln_Read
        '
        Me.Cln_Read.DataPropertyName = "Chk"
        Me.Cln_Read.HeaderText = "خوانده شده"
        Me.Cln_Read.Name = "Cln_Read"
        Me.Cln_Read.ReadOnly = True
        Me.Cln_Read.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cln_Read.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Cln_Read.Visible = False
        Me.Cln_Read.Width = 50
        '
        'Cln_RDate
        '
        Me.Cln_RDate.DataPropertyName = "R_Date"
        Me.Cln_RDate.HeaderText = "تاریخ دریافت"
        Me.Cln_RDate.Name = "Cln_RDate"
        Me.Cln_RDate.ReadOnly = True
        Me.Cln_RDate.Visible = False
        '
        'Sender_IdUser
        '
        Me.Sender_IdUser.DataPropertyName = "Sender_IdUser"
        Me.Sender_IdUser.HeaderText = "Sender_IdUser"
        Me.Sender_IdUser.Name = "Sender_IdUser"
        Me.Sender_IdUser.ReadOnly = True
        Me.Sender_IdUser.Visible = False
        '
        'Sender_IdVisitor
        '
        Me.Sender_IdVisitor.DataPropertyName = "Sender_IdVisitor"
        Me.Sender_IdVisitor.HeaderText = "Sender_IdVisitor"
        Me.Sender_IdVisitor.Name = "Sender_IdVisitor"
        Me.Sender_IdVisitor.ReadOnly = True
        Me.Sender_IdVisitor.Visible = False
        '
        'Reciver_IdUser
        '
        Me.Reciver_IdUser.DataPropertyName = "Reciver_IdUser"
        Me.Reciver_IdUser.HeaderText = "Reciver_IdUser"
        Me.Reciver_IdUser.Name = "Reciver_IdUser"
        Me.Reciver_IdUser.ReadOnly = True
        Me.Reciver_IdUser.Visible = False
        '
        'Reciver_IdVisitor
        '
        Me.Reciver_IdVisitor.DataPropertyName = "Reciver_IdVisitor"
        Me.Reciver_IdVisitor.HeaderText = "Reciver_IdVisitor"
        Me.Reciver_IdVisitor.Name = "Reciver_IdVisitor"
        Me.Reciver_IdVisitor.ReadOnly = True
        Me.Reciver_IdVisitor.Visible = False
        '
        'Cln_Message
        '
        Me.Cln_Message.DataPropertyName = "Message"
        Me.Cln_Message.HeaderText = "Message"
        Me.Cln_Message.Name = "Cln_Message"
        Me.Cln_Message.ReadOnly = True
        Me.Cln_Message.Visible = False
        '
        'RChk
        '
        Me.RChk.DataPropertyName = "RChk"
        Me.RChk.HeaderText = "RChk"
        Me.RChk.Name = "RChk"
        Me.RChk.ReadOnly = True
        Me.RChk.Visible = False
        '
        'Response
        '
        Me.Response.DataPropertyName = "Response"
        Me.Response.HeaderText = "Response"
        Me.Response.Name = "Response"
        Me.Response.ReadOnly = True
        Me.Response.Visible = False
        '
        'FrmMessageCenter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 475)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ListV)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "FrmMessageCenter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مرکز پیام"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents ListV As System.Windows.Forms.ListView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents BtnDell As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Cln_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Dat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Sender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Reciver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Subject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Read As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cln_RDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sender_IdUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sender_IdVisitor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reciver_IdUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reciver_IdVisitor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cln_Message As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RChk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Response As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
