<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInfoStateMoney
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
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ChkTime = New System.Windows.Forms.CheckBox
        Me.ChkTa = New System.Windows.Forms.CheckBox
        Me.ChkAz = New System.Windows.Forms.CheckBox
        Me.Txt_Date = New FarsiDate.FarsiDate
        Me.Txt_Date1 = New FarsiDate.FarsiDate
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.TxtCountPay = New System.Windows.Forms.TextBox
        Me.TxtMonPay = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCountGet = New System.Windows.Forms.TextBox
        Me.TxtMonGet = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtDiff = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.TxtBank = New System.Windows.Forms.TextBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtBox = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.TxtDelayPay = New System.Windows.Forms.TextBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtDelayGet = New System.Windows.Forms.TextBox
        Me.Chkdelay = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(15, 35)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 31)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "تهيه گزارش"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChkTime)
        Me.GroupBox1.Controls.Add(Me.ChkTa)
        Me.GroupBox1.Controls.Add(Me.ChkAz)
        Me.GroupBox1.Controls.Add(Me.Txt_Date)
        Me.GroupBox1.Controls.Add(Me.Txt_Date1)
        Me.GroupBox1.Location = New System.Drawing.Point(123, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(351, 76)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'ChkTime
        '
        Me.ChkTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTime.AutoSize = True
        Me.ChkTime.Location = New System.Drawing.Point(225, 0)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(109, 25)
        Me.ChkTime.TabIndex = 14
        Me.ChkTime.Text = "محدودیت زمانی"
        Me.ChkTime.UseVisualStyleBackColor = True
        '
        'ChkTa
        '
        Me.ChkTa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkTa.AutoSize = True
        Me.ChkTa.Location = New System.Drawing.Point(130, 31)
        Me.ChkTa.Name = "ChkTa"
        Me.ChkTa.Size = New System.Drawing.Size(36, 25)
        Me.ChkTa.TabIndex = 13
        Me.ChkTa.Text = "تا"
        Me.ChkTa.UseVisualStyleBackColor = True
        '
        'ChkAz
        '
        Me.ChkAz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkAz.AutoSize = True
        Me.ChkAz.Location = New System.Drawing.Point(297, 31)
        Me.ChkAz.Name = "ChkAz"
        Me.ChkAz.Size = New System.Drawing.Size(37, 25)
        Me.ChkAz.TabIndex = 12
        Me.ChkAz.Text = "از"
        Me.ChkAz.UseVisualStyleBackColor = True
        '
        'Txt_Date
        '
        Me.Txt_Date.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Date.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Txt_Date.Location = New System.Drawing.Point(181, 30)
        Me.Txt_Date.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Txt_Date.Name = "Txt_Date"
        Me.Txt_Date.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Txt_Date.Size = New System.Drawing.Size(113, 29)
        Me.Txt_Date.TabIndex = 11
        Me.Txt_Date.ThisText = Nothing
        '
        'Txt_Date1
        '
        Me.Txt_Date1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Txt_Date1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Txt_Date1.Location = New System.Drawing.Point(8, 30)
        Me.Txt_Date1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Txt_Date1.Name = "Txt_Date1"
        Me.Txt_Date1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Txt_Date1.Size = New System.Drawing.Size(119, 29)
        Me.Txt_Date1.TabIndex = 10
        Me.Txt_Date1.ThisText = Nothing
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.TxtCountPay)
        Me.GroupBox2.Controls.Add(Me.TxtMonPay)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TxtCountGet)
        Me.GroupBox2.Controls.Add(Me.TxtMonGet)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 85)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(467, 102)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "اطلاع رسانی چکها"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(227, 62)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 21)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "جمع پرداختی"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button3.Location = New System.Drawing.Point(8, 58)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 30)
        Me.Button3.TabIndex = 112
        Me.Button3.Text = "لیست"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TxtCountPay
        '
        Me.TxtCountPay.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCountPay.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtCountPay.Location = New System.Drawing.Point(318, 59)
        Me.TxtCountPay.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtCountPay.Name = "TxtCountPay"
        Me.TxtCountPay.ReadOnly = True
        Me.TxtCountPay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtCountPay.Size = New System.Drawing.Size(51, 29)
        Me.TxtCountPay.TabIndex = 110
        Me.TxtCountPay.Text = "0"
        Me.TxtCountPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtMonPay
        '
        Me.TxtMonPay.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMonPay.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtMonPay.Location = New System.Drawing.Point(58, 59)
        Me.TxtMonPay.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtMonPay.Name = "TxtMonPay"
        Me.TxtMonPay.ReadOnly = True
        Me.TxtMonPay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtMonPay.Size = New System.Drawing.Size(159, 29)
        Me.TxtMonPay.TabIndex = 111
        Me.TxtMonPay.Text = "0"
        Me.TxtMonPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Location = New System.Drawing.Point(8, 26)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 30)
        Me.Button1.TabIndex = 111
        Me.Button1.Text = "لیست"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(383, 62)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 21)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "تعداد پرداختی"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(227, 30)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 21)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "جمع دريافتی"
        '
        'TxtCountGet
        '
        Me.TxtCountGet.BackColor = System.Drawing.SystemColors.Window
        Me.TxtCountGet.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtCountGet.Location = New System.Drawing.Point(318, 27)
        Me.TxtCountGet.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtCountGet.Name = "TxtCountGet"
        Me.TxtCountGet.ReadOnly = True
        Me.TxtCountGet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtCountGet.Size = New System.Drawing.Size(51, 29)
        Me.TxtCountGet.TabIndex = 3
        Me.TxtCountGet.Text = "0"
        Me.TxtCountGet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtMonGet
        '
        Me.TxtMonGet.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMonGet.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtMonGet.Location = New System.Drawing.Point(58, 27)
        Me.TxtMonGet.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtMonGet.Name = "TxtMonGet"
        Me.TxtMonGet.ReadOnly = True
        Me.TxtMonGet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtMonGet.Size = New System.Drawing.Size(159, 29)
        Me.TxtMonGet.TabIndex = 4
        Me.TxtMonGet.Text = "0"
        Me.TxtMonGet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(383, 30)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 21)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "تعداد دريافتی"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(383, 25)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 21)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "اختلاف حساب"
        '
        'TxtDiff
        '
        Me.TxtDiff.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDiff.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtDiff.Location = New System.Drawing.Point(58, 22)
        Me.TxtDiff.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtDiff.Name = "TxtDiff"
        Me.TxtDiff.ReadOnly = True
        Me.TxtDiff.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDiff.Size = New System.Drawing.Size(311, 29)
        Me.TxtDiff.TabIndex = 114
        Me.TxtDiff.Text = "0"
        Me.TxtDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.TxtBank)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.TxtBox)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 189)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(467, 102)
        Me.GroupBox3.TabIndex = 114
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "اطلاع رسانی بانک و صندوق"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(405, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 21)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "جمع بانک"
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button4.Location = New System.Drawing.Point(8, 58)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(50, 30)
        Me.Button4.TabIndex = 112
        Me.Button4.Text = "لیست"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TxtBank
        '
        Me.TxtBank.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBank.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtBank.Location = New System.Drawing.Point(58, 59)
        Me.TxtBank.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtBank.Name = "TxtBank"
        Me.TxtBank.ReadOnly = True
        Me.TxtBank.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBank.Size = New System.Drawing.Size(311, 29)
        Me.TxtBank.TabIndex = 111
        Me.TxtBank.Text = "0"
        Me.TxtBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button5.Location = New System.Drawing.Point(8, 26)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(50, 30)
        Me.Button5.TabIndex = 111
        Me.Button5.Text = "لیست"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.Location = New System.Drawing.Point(392, 31)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 21)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "جمع صندوق"
        '
        'TxtBox
        '
        Me.TxtBox.BackColor = System.Drawing.SystemColors.Window
        Me.TxtBox.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtBox.Location = New System.Drawing.Point(58, 27)
        Me.TxtBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtBox.Name = "TxtBox"
        Me.TxtBox.ReadOnly = True
        Me.TxtBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtBox.Size = New System.Drawing.Size(311, 29)
        Me.TxtBox.TabIndex = 4
        Me.TxtBox.Text = "0"
        Me.TxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Chkdelay)
        Me.GroupBox4.Controls.Add(Me.TxtDiff)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 397)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(467, 90)
        Me.GroupBox4.TabIndex = 115
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "نتيجه نهايی"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 489)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(482, 29)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 116
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(54, 24)
        Me.ToolStripStatusLabel1.Text = "F1 راهنما"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(80, 24)
        Me.ToolStripStatusLabel6.Text = "F2 تهیه گزارش"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Button6)
        Me.GroupBox5.Controls.Add(Me.TxtDelayPay)
        Me.GroupBox5.Controls.Add(Me.Button7)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.TxtDelayGet)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 295)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox5.Size = New System.Drawing.Size(467, 102)
        Me.GroupBox5.TabIndex = 115
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "اطلاع رسانی وعده ها"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(384, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 21)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "وعده پرداختی"
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button6.Location = New System.Drawing.Point(8, 58)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(50, 30)
        Me.Button6.TabIndex = 112
        Me.Button6.Text = "لیست"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TxtDelayPay
        '
        Me.TxtDelayPay.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDelayPay.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtDelayPay.Location = New System.Drawing.Point(58, 59)
        Me.TxtDelayPay.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtDelayPay.Name = "TxtDelayPay"
        Me.TxtDelayPay.ReadOnly = True
        Me.TxtDelayPay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDelayPay.Size = New System.Drawing.Size(311, 29)
        Me.TxtDelayPay.TabIndex = 111
        Me.TxtDelayPay.Text = "0"
        Me.TxtDelayPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button7.Location = New System.Drawing.Point(8, 26)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(50, 30)
        Me.Button7.TabIndex = 111
        Me.Button7.Text = "لیست"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(384, 30)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 21)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "وعده دریافتی"
        '
        'TxtDelayGet
        '
        Me.TxtDelayGet.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDelayGet.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtDelayGet.Location = New System.Drawing.Point(58, 27)
        Me.TxtDelayGet.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtDelayGet.Name = "TxtDelayGet"
        Me.TxtDelayGet.ReadOnly = True
        Me.TxtDelayGet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDelayGet.Size = New System.Drawing.Size(311, 29)
        Me.TxtDelayGet.TabIndex = 4
        Me.TxtDelayGet.Text = "0"
        Me.TxtDelayGet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Chkdelay
        '
        Me.Chkdelay.AutoSize = True
        Me.Chkdelay.Checked = True
        Me.Chkdelay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Chkdelay.Location = New System.Drawing.Point(80, 57)
        Me.Chkdelay.Name = "Chkdelay"
        Me.Chkdelay.Size = New System.Drawing.Size(289, 25)
        Me.Chkdelay.TabIndex = 116
        Me.Chkdelay.Text = "وعده دریافتی و پرداختی در نتیجه نهایی تاثیر داده شود"
        Me.Chkdelay.UseVisualStyleBackColor = True
        '
        'FrmInfoStateMoney
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 518)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInfoStateMoney"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اطلاع رسانی مالی"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCountPay As System.Windows.Forms.TextBox
    Friend WithEvents TxtMonPay As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCountGet As System.Windows.Forms.TextBox
    Friend WithEvents TxtMonGet As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtDiff As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TxtBank As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTa As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAz As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_Date As FarsiDate.FarsiDate
    Friend WithEvents Txt_Date1 As FarsiDate.FarsiDate
    Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TxtDelayPay As System.Windows.Forms.TextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtDelayGet As System.Windows.Forms.TextBox
    Friend WithEvents Chkdelay As System.Windows.Forms.CheckBox
End Class
