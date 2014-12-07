using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iCatTools.socket;
using iCatTools.command;
using iCatTools.common;

namespace iCatTools.Frm
{
    public partial class SendMessage : Form
    {
        public SendMessage()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            AbstractSendCMD sendCmd = new SendMsg(ApplicationBase.KeyUser, this.tbSendToSrv.Text.Trim());
            CommandFactory cmdFactory = new CommandFactory(sendCmd);
            TcpClt tcpclt = new TcpClt();
            int sentCount = 0;
            if (MainForm._srvIp != string.Empty)
            {
                tcpclt.ConnectSrvAndSend(MainForm._srvIp, MainForm._srvPort, cmdFactory.GetCommand(), ref sentCount);
            }
            this.tbSendToSrv.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
