using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PosInterface;

namespace UnitTesting
{
    public partial class PcPosPage : Form, ITransactionDoneHandler
    {
        private PCPos _pcPos;

        public PcPosPage()
        {
            InitializeComponent();
        }

        private  void btnTest_Click(object sender, EventArgs e)
        {
            _pcPos.DoASyncPayment(this.txtprice.Text, string.Empty,string.Empty, string.Empty, DateTime.Now, this);

        }

        public void OnTransactionDone(TransactionResult result)
        {
            this.lstResult.Invoke(new Action(() =>
            {
                this.lstResult.Items.Add(result);
            }));
        }

        public void OnFinish(string message)
        {
            this.lstResult.Invoke(new Action(() =>
            {
                this.lstResult.Items.Add("Finish Received: " + message);
            }));
        }

        public PosInquiryTitleResponseModel OnTitleRequest()
        {
            throw new NotImplementedException();
        }

        public void OnPosInquiryRequest(string data, string ip)
        {
            throw new NotImplementedException();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            _pcPos = new PCPos(int.Parse(this.txtPort.Text));
            _pcPos.ListenPos(this);
            if (this.cmbConnectionType.SelectedIndex == 0)
                _pcPos.InitLAN(this.txtIp.Text);
            else
                _pcPos.InitSerial(this.txtSerialPortName.Text, int.Parse(this.txtBaudRate.Text));
        }
    }
}
