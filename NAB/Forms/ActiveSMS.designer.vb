<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActiveSMS
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActiveSMS))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboPort = New System.Windows.Forms.ComboBox
        Me.cboBaudRate = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbProtocol = New System.Windows.Forms.ComboBox
        Me.PINCode = New System.Windows.Forms.TextBox
        Me.cmbMode = New System.Windows.Forms.ComboBox
        Me.btnDisconnect = New System.Windows.Forms.Button
        Me.btnConnect = New System.Windows.Forms.Button
        Me.axKylixSMS = New AxKYLIXSMSLib.AxKylixSMS
        Me.gbDevice = New System.Windows.Forms.GroupBox
        Me.cmbSMSFolder = New System.Windows.Forms.ComboBox
        Me.label11 = New System.Windows.Forms.Label
        Me.txtManufacture = New System.Windows.Forms.TextBox
        Me.txtSMSCNumber = New System.Windows.Forms.TextBox
        Me.label12 = New System.Windows.Forms.Label
        Me.label15 = New System.Windows.Forms.Label
        Me.label16 = New System.Windows.Forms.Label
        Me.txtModel = New System.Windows.Forms.TextBox
        Me.label17 = New System.Windows.Forms.Label
        Me.label18 = New System.Windows.Forms.Label
        Me.txtNetwork = New System.Windows.Forms.TextBox
        Me.txtIMEI = New System.Windows.Forms.TextBox
        Me.txtSignal = New System.Windows.Forms.TextBox
        Me.txtBattery = New System.Windows.Forms.TextBox
        Me.label19 = New System.Windows.Forms.Label
        Me.label20 = New System.Windows.Forms.Label
        Me.txtFirmware = New System.Windows.Forms.TextBox
        Me.label21 = New System.Windows.Forms.Label
        Me.label22 = New System.Windows.Forms.Label
        Me.txtHardware = New System.Windows.Forms.TextBox
        Me.txtTime = New System.Windows.Forms.TextBox
        Me.label23 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cbAutoDeleteNewSMS = New System.Windows.Forms.CheckBox
        Me.cbAutoDeleteAllReport = New System.Windows.Forms.CheckBox
        Me.cbRequestReport = New System.Windows.Forms.CheckBox
        Me.cbIsConcatenatedSMS = New System.Windows.Forms.CheckBox
        Me.NI1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.BtnWait = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.TxtCode = New System.Windows.Forms.TextBox
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1.SuspendLayout()
        CType(Me.axKylixSMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDevice.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboPort)
        Me.GroupBox1.Controls.Add(Me.cboBaudRate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbProtocol)
        Me.GroupBox1.Controls.Add(Me.PINCode)
        Me.GroupBox1.Controls.Add(Me.cmbMode)
        Me.GroupBox1.Location = New System.Drawing.Point(258, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(325, 186)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "اتصال به دستگاه"
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button5.Location = New System.Drawing.Point(6, 150)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(27, 28)
        Me.Button5.TabIndex = 27
        Me.Button5.Text = "؟"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button4.Location = New System.Drawing.Point(6, 119)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(27, 28)
        Me.Button4.TabIndex = 26
        Me.Button4.Text = "؟"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button3.Location = New System.Drawing.Point(6, 87)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(27, 28)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "؟"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(208, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 21)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "نحوه ارتباط با دستگاه"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button2.Location = New System.Drawing.Point(6, 25)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 28)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "؟"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Location = New System.Drawing.Point(6, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 28)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "؟"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(209, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 21)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "سرعت پورت دستگاه"
        '
        'cboPort
        '
        Me.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPort.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cboPort.Location = New System.Drawing.Point(39, 87)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(154, 28)
        Me.cboPort.TabIndex = 11
        '
        'cboBaudRate
        '
        Me.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaudRate.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cboBaudRate.Location = New System.Drawing.Point(39, 118)
        Me.cboBaudRate.Name = "cboBaudRate"
        Me.cboBaudRate.Size = New System.Drawing.Size(154, 29)
        Me.cboBaudRate.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(210, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 21)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "پین کد(Pin Code)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(216, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 21)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "پورت مورد استفاده"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(199, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 21)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "پروتکل ارتباط با دستگاه"
        '
        'cmbProtocol
        '
        Me.cmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProtocol.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbProtocol.Items.AddRange(New Object() {"AT Command", "Nokia FBUS", "Nokia MBUS"})
        Me.cmbProtocol.Location = New System.Drawing.Point(39, 56)
        Me.cmbProtocol.Name = "cmbProtocol"
        Me.cmbProtocol.Size = New System.Drawing.Size(154, 28)
        Me.cmbProtocol.TabIndex = 4
        '
        'PINCode
        '
        Me.PINCode.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PINCode.Location = New System.Drawing.Point(39, 150)
        Me.PINCode.Name = "PINCode"
        Me.PINCode.Size = New System.Drawing.Size(154, 27)
        Me.PINCode.TabIndex = 5
        '
        'cmbMode
        '
        Me.cmbMode.DisplayMember = "0"
        Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMode.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbMode.Items.AddRange(New Object() {"Physical/Virtual COM", "Infrared", "Bluetooth", "USB"})
        Me.cmbMode.Location = New System.Drawing.Point(39, 25)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New System.Drawing.Size(154, 28)
        Me.cmbMode.TabIndex = 2
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Enabled = False
        Me.btnDisconnect.Location = New System.Drawing.Point(405, 383)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(86, 30)
        Me.btnDisconnect.TabIndex = 18
        Me.btnDisconnect.Text = "قطع اتصال"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConnect.Location = New System.Drawing.Point(497, 383)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(86, 30)
        Me.btnConnect.TabIndex = 17
        Me.btnConnect.Text = "اتصال"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'axKylixSMS
        '
        Me.axKylixSMS.Enabled = True
        Me.axKylixSMS.Location = New System.Drawing.Point(12, 381)
        Me.axKylixSMS.Name = "axKylixSMS"
        Me.axKylixSMS.OcxState = CType(resources.GetObject("axKylixSMS.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axKylixSMS.Size = New System.Drawing.Size(32, 32)
        Me.axKylixSMS.TabIndex = 16
        '
        'gbDevice
        '
        Me.gbDevice.Controls.Add(Me.cmbSMSFolder)
        Me.gbDevice.Controls.Add(Me.label11)
        Me.gbDevice.Controls.Add(Me.txtManufacture)
        Me.gbDevice.Controls.Add(Me.txtSMSCNumber)
        Me.gbDevice.Controls.Add(Me.label12)
        Me.gbDevice.Controls.Add(Me.label15)
        Me.gbDevice.Controls.Add(Me.label16)
        Me.gbDevice.Controls.Add(Me.txtModel)
        Me.gbDevice.Controls.Add(Me.label17)
        Me.gbDevice.Controls.Add(Me.label18)
        Me.gbDevice.Controls.Add(Me.txtNetwork)
        Me.gbDevice.Controls.Add(Me.txtIMEI)
        Me.gbDevice.Controls.Add(Me.txtSignal)
        Me.gbDevice.Controls.Add(Me.txtBattery)
        Me.gbDevice.Controls.Add(Me.label19)
        Me.gbDevice.Controls.Add(Me.label20)
        Me.gbDevice.Controls.Add(Me.txtFirmware)
        Me.gbDevice.Controls.Add(Me.label21)
        Me.gbDevice.Controls.Add(Me.label22)
        Me.gbDevice.Controls.Add(Me.txtHardware)
        Me.gbDevice.Controls.Add(Me.txtTime)
        Me.gbDevice.Controls.Add(Me.label23)
        Me.gbDevice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gbDevice.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.gbDevice.Location = New System.Drawing.Point(12, 12)
        Me.gbDevice.Name = "gbDevice"
        Me.gbDevice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.gbDevice.Size = New System.Drawing.Size(240, 364)
        Me.gbDevice.TabIndex = 19
        Me.gbDevice.TabStop = False
        Me.gbDevice.Text = "مشخصات دستگاه"
        '
        'cmbSMSFolder
        '
        Me.cmbSMSFolder.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbSMSFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSMSFolder.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmbSMSFolder.Location = New System.Drawing.Point(83, 328)
        Me.cmbSMSFolder.Name = "cmbSMSFolder"
        Me.cmbSMSFolder.Size = New System.Drawing.Size(151, 29)
        Me.cmbSMSFolder.TabIndex = 20
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label11.Location = New System.Drawing.Point(29, 332)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(44, 20)
        Me.label11.TabIndex = 21
        Me.label11.Text = "Folder"
        '
        'txtManufacture
        '
        Me.txtManufacture.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtManufacture.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtManufacture.Location = New System.Drawing.Point(83, 22)
        Me.txtManufacture.Name = "txtManufacture"
        Me.txtManufacture.ReadOnly = True
        Me.txtManufacture.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtManufacture.Size = New System.Drawing.Size(151, 29)
        Me.txtManufacture.TabIndex = 1
        '
        'txtSMSCNumber
        '
        Me.txtSMSCNumber.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSMSCNumber.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtSMSCNumber.Location = New System.Drawing.Point(83, 296)
        Me.txtSMSCNumber.Name = "txtSMSCNumber"
        Me.txtSMSCNumber.ReadOnly = True
        Me.txtSMSCNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSMSCNumber.Size = New System.Drawing.Size(151, 29)
        Me.txtSMSCNumber.TabIndex = 20
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label12.Location = New System.Drawing.Point(29, 299)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(44, 20)
        Me.label12.TabIndex = 21
        Me.label12.Text = "SMSC"
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label15.Location = New System.Drawing.Point(2, 26)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(78, 20)
        Me.label15.TabIndex = 0
        Me.label15.Text = "Manufacture"
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label16.Location = New System.Drawing.Point(34, 56)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(44, 20)
        Me.label16.TabIndex = 0
        Me.label16.Text = "Model"
        '
        'txtModel
        '
        Me.txtModel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtModel.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtModel.Location = New System.Drawing.Point(83, 52)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.ReadOnly = True
        Me.txtModel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtModel.Size = New System.Drawing.Size(151, 29)
        Me.txtModel.TabIndex = 1
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label17.Location = New System.Drawing.Point(40, 87)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(34, 20)
        Me.label17.TabIndex = 0
        Me.label17.Text = "IMEI"
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label18.Location = New System.Drawing.Point(22, 117)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(54, 20)
        Me.label18.TabIndex = 0
        Me.label18.Text = "Network"
        '
        'txtNetwork
        '
        Me.txtNetwork.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNetwork.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtNetwork.Location = New System.Drawing.Point(83, 113)
        Me.txtNetwork.Name = "txtNetwork"
        Me.txtNetwork.ReadOnly = True
        Me.txtNetwork.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNetwork.Size = New System.Drawing.Size(151, 29)
        Me.txtNetwork.TabIndex = 1
        '
        'txtIMEI
        '
        Me.txtIMEI.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtIMEI.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtIMEI.Location = New System.Drawing.Point(83, 82)
        Me.txtIMEI.Name = "txtIMEI"
        Me.txtIMEI.ReadOnly = True
        Me.txtIMEI.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIMEI.Size = New System.Drawing.Size(151, 29)
        Me.txtIMEI.TabIndex = 1
        '
        'txtSignal
        '
        Me.txtSignal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSignal.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtSignal.Location = New System.Drawing.Point(83, 173)
        Me.txtSignal.Name = "txtSignal"
        Me.txtSignal.ReadOnly = True
        Me.txtSignal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSignal.Size = New System.Drawing.Size(151, 29)
        Me.txtSignal.TabIndex = 1
        '
        'txtBattery
        '
        Me.txtBattery.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtBattery.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtBattery.Location = New System.Drawing.Point(83, 143)
        Me.txtBattery.Name = "txtBattery"
        Me.txtBattery.ReadOnly = True
        Me.txtBattery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBattery.Size = New System.Drawing.Size(151, 29)
        Me.txtBattery.TabIndex = 1
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label19.Location = New System.Drawing.Point(34, 178)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(44, 20)
        Me.label19.TabIndex = 0
        Me.label19.Text = "Signal"
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label20.Location = New System.Drawing.Point(28, 147)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(46, 20)
        Me.label20.TabIndex = 0
        Me.label20.Text = "Battery"
        '
        'txtFirmware
        '
        Me.txtFirmware.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFirmware.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtFirmware.Location = New System.Drawing.Point(83, 204)
        Me.txtFirmware.Name = "txtFirmware"
        Me.txtFirmware.ReadOnly = True
        Me.txtFirmware.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFirmware.Size = New System.Drawing.Size(151, 29)
        Me.txtFirmware.TabIndex = 1
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label21.Location = New System.Drawing.Point(15, 238)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(63, 20)
        Me.label21.TabIndex = 0
        Me.label21.Text = "Hardware"
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label22.Location = New System.Drawing.Point(17, 208)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(61, 20)
        Me.label22.TabIndex = 0
        Me.label22.Text = "Firmware"
        '
        'txtHardware
        '
        Me.txtHardware.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtHardware.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtHardware.Location = New System.Drawing.Point(83, 234)
        Me.txtHardware.Name = "txtHardware"
        Me.txtHardware.ReadOnly = True
        Me.txtHardware.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHardware.Size = New System.Drawing.Size(151, 29)
        Me.txtHardware.TabIndex = 1
        '
        'txtTime
        '
        Me.txtTime.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtTime.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTime.Location = New System.Drawing.Point(83, 264)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ReadOnly = True
        Me.txtTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTime.Size = New System.Drawing.Size(151, 29)
        Me.txtTime.TabIndex = 1
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label23.Location = New System.Drawing.Point(38, 267)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(37, 20)
        Me.label23.TabIndex = 0
        Me.label23.Text = "Time"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbAutoDeleteNewSMS)
        Me.GroupBox2.Controls.Add(Me.cbAutoDeleteAllReport)
        Me.GroupBox2.Controls.Add(Me.cbRequestReport)
        Me.GroupBox2.Controls.Add(Me.cbIsConcatenatedSMS)
        Me.GroupBox2.Location = New System.Drawing.Point(258, 204)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(325, 105)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "تنظیمات"
        '
        'cbAutoDeleteNewSMS
        '
        Me.cbAutoDeleteNewSMS.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbAutoDeleteNewSMS.Location = New System.Drawing.Point(4, 27)
        Me.cbAutoDeleteNewSMS.Name = "cbAutoDeleteNewSMS"
        Me.cbAutoDeleteNewSMS.Size = New System.Drawing.Size(154, 24)
        Me.cbAutoDeleteNewSMS.TabIndex = 7
        Me.cbAutoDeleteNewSMS.Text = "حذف خودکار SMS جدید"
        '
        'cbAutoDeleteAllReport
        '
        Me.cbAutoDeleteAllReport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbAutoDeleteAllReport.Location = New System.Drawing.Point(6, 63)
        Me.cbAutoDeleteAllReport.Name = "cbAutoDeleteAllReport"
        Me.cbAutoDeleteAllReport.Size = New System.Drawing.Size(152, 23)
        Me.cbAutoDeleteAllReport.TabIndex = 6
        Me.cbAutoDeleteAllReport.Text = "حذف خودکار تمام گزارشها"
        '
        'cbRequestReport
        '
        Me.cbRequestReport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbRequestReport.Location = New System.Drawing.Point(161, 62)
        Me.cbRequestReport.Name = "cbRequestReport"
        Me.cbRequestReport.Size = New System.Drawing.Size(154, 24)
        Me.cbRequestReport.TabIndex = 5
        Me.cbRequestReport.Text = "درخواست گزارش تحویل"
        '
        'cbIsConcatenatedSMS
        '
        Me.cbIsConcatenatedSMS.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbIsConcatenatedSMS.Location = New System.Drawing.Point(133, 26)
        Me.cbIsConcatenatedSMS.Name = "cbIsConcatenatedSMS"
        Me.cbIsConcatenatedSMS.Size = New System.Drawing.Size(182, 29)
        Me.cbIsConcatenatedSMS.TabIndex = 4
        Me.cbIsConcatenatedSMS.Text = "متنSMS  به هم پیوسته"
        '
        'NI1
        '
        Me.NI1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NI1.BalloonTipTitle = "حسابداری ناب"
        Me.NI1.Icon = CType(resources.GetObject("NI1.Icon"), System.Drawing.Icon)
        Me.NI1.Text = "سیستم پیامک"
        Me.NI1.Visible = True
        '
        'BtnWait
        '
        Me.BtnWait.Enabled = False
        Me.BtnWait.Location = New System.Drawing.Point(12, 381)
        Me.BtnWait.Name = "BtnWait"
        Me.BtnWait.Size = New System.Drawing.Size(86, 30)
        Me.BtnWait.TabIndex = 21
        Me.BtnWait.Text = "حالت انتظار"
        Me.BtnWait.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 417)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(591, 29)
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(51, 24)
        Me.ToolStripStatusLabel2.Text = "F2 اتصال"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(72, 24)
        Me.ToolStripStatusLabel4.Text = "F3 قطع اتصال"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(51, 24)
        Me.ToolStripStatusLabel3.Text = "Dial F6"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(64, 24)
        Me.ToolStripStatusLabel8.Text = "ESC خروج"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.TxtCode)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(258, 315)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(325, 61)
        Me.GroupBox3.TabIndex = 63
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "خدمات سیم کارت"
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button6.Location = New System.Drawing.Point(252, 23)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(63, 30)
        Me.Button6.TabIndex = 23
        Me.Button6.Text = "Dial"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'TxtCode
        '
        Me.TxtCode.Font = New System.Drawing.Font("B Traffic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtCode.Location = New System.Drawing.Point(6, 23)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtCode.Size = New System.Drawing.Size(240, 27)
        Me.TxtCode.TabIndex = 28
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(76, 24)
        Me.ToolStripStatusLabel5.Text = "F4 حالت انتظار"
        '
        'ActiveSMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 446)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnWait)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbDevice)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.axKylixSMS)
        Me.Font = New System.Drawing.Font("B Traffic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ActiveSMS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMS برقراری ارتباط با دستگاه"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.axKylixSMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDevice.ResumeLayout(False)
        Me.gbDevice.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents cmbMode As System.Windows.Forms.ComboBox
    Private WithEvents cmbProtocol As System.Windows.Forms.ComboBox
    Private WithEvents PINCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Private WithEvents cboPort As System.Windows.Forms.ComboBox
    Private WithEvents cboBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents gbDevice As System.Windows.Forms.GroupBox
    Private WithEvents txtManufacture As System.Windows.Forms.TextBox
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents txtModel As System.Windows.Forms.TextBox
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents txtNetwork As System.Windows.Forms.TextBox
    Private WithEvents txtIMEI As System.Windows.Forms.TextBox
    Private WithEvents txtSignal As System.Windows.Forms.TextBox
    Private WithEvents txtBattery As System.Windows.Forms.TextBox
    Private WithEvents label19 As System.Windows.Forms.Label
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents txtFirmware As System.Windows.Forms.TextBox
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents txtHardware As System.Windows.Forms.TextBox
    Private WithEvents txtTime As System.Windows.Forms.TextBox
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents txtSMSCNumber As System.Windows.Forms.TextBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents cmbSMSFolder As System.Windows.Forms.ComboBox
    Private WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents cbIsConcatenatedSMS As System.Windows.Forms.CheckBox
    Private WithEvents cbRequestReport As System.Windows.Forms.CheckBox
    Private WithEvents cbAutoDeleteNewSMS As System.Windows.Forms.CheckBox
    Private WithEvents cbAutoDeleteAllReport As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents NI1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents BtnWait As System.Windows.Forms.Button
    Public WithEvents axKylixSMS As AxKYLIXSMSLib.AxKylixSMS
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Private WithEvents TxtCode As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel

End Class
