namespace UnitTesting
{
    partial class PcPosPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerialPortName = new System.Windows.Forms.TextBox();
            this.txtBaudRate = new System.Windows.Forms.TextBox();
            this.cmbConnectionType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(134, 12);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(182, 30);
            this.txtIp.TabIndex = 0;
            this.txtIp.Text = "169.254.173.247";
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(12, 48);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(304, 30);
            this.txtprice.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "آدرس شبکه";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "مبلغ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "نوع ارتباط";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(237, 287);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(186, 31);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "تست";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lstResult
            // 
            this.lstResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 22;
            this.lstResult.Location = new System.Drawing.Point(5, 324);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(418, 246);
            this.lstResult.TabIndex = 9;
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(5, 287);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(186, 31);
            this.btnConfig.TabIndex = 7;
            this.btnConfig.Text = "پیکر بندی";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(12, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(80, 30);
            this.txtPort.TabIndex = 10;
            this.txtPort.Text = "17000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "پورت";
            // 
            // txtSerialPortName
            // 
            this.txtSerialPortName.Location = new System.Drawing.Point(12, 120);
            this.txtSerialPortName.Name = "txtSerialPortName";
            this.txtSerialPortName.Size = new System.Drawing.Size(304, 30);
            this.txtSerialPortName.TabIndex = 12;
            this.txtSerialPortName.Text = "COM2";
            // 
            // txtBaudRate
            // 
            this.txtBaudRate.Location = new System.Drawing.Point(12, 156);
            this.txtBaudRate.Name = "txtBaudRate";
            this.txtBaudRate.Size = new System.Drawing.Size(304, 30);
            this.txtBaudRate.TabIndex = 15;
            this.txtBaudRate.Text = "115200";
            // 
            // cmbConnectionType
            // 
            this.cmbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConnectionType.FormattingEnabled = true;
            this.cmbConnectionType.Items.AddRange(new object[] {
            "LAN",
            "COM"});
            this.cmbConnectionType.Location = new System.Drawing.Point(12, 84);
            this.cmbConnectionType.Name = "cmbConnectionType";
            this.cmbConnectionType.Size = new System.Drawing.Size(304, 30);
            this.cmbConnectionType.TabIndex = 20;
            // 
            // PcPosPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(428, 576);
            this.Controls.Add(this.cmbConnectionType);
            this.Controls.Add(this.txtBaudRate);
            this.Controls.Add(this.txtSerialPortName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.txtIp);
            this.Font = new System.Drawing.Font("IRANSans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "PcPosPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PC POS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerialPortName;
        private System.Windows.Forms.TextBox txtBaudRate;
        private System.Windows.Forms.ComboBox cmbConnectionType;
    }
}

