using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenServer.socket;
using GenServer.command;

namespace GenServer.Frm
{
    public partial class SendVersionFrm : Form
    {
        public SendVersionFrm()
        {
            InitializeComponent();
        }
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            AbstractSendCMD sendCmd = new SendAppVersion("bhlfyServer", "1.0.1.23232");
            CommandFactory cmdFactory = new CommandFactory(sendCmd);
            TcpClt tcpclt = new TcpClt();
            int sentCount = 0;
            //if (MainForm._srvIp != string.Empty)
            //{
                tcpclt.ConnectSrvAndSend("192.163.20.48", 1010, cmdFactory.GetCommand(), ref sentCount);
            //}
        }

        private void SendVersionFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
