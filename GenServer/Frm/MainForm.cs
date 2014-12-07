using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenServer.socket;
using System.Threading;
using System.IO;
using GenServer.common;

namespace GenServer.Frm
{
    public partial class MainForm : Form
    {
        private Thread thdStartListen = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            #endregion
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IconStatus iconStatus = new IconStatus(this.nIconSystem, this);
            iconStatus.SetIcon();
        }

        private void tsmStartListen_Click(object sender, EventArgs e)
        {
            this.thdStartListen = new Thread(new ThreadStart(this.thdStartListenFunc));
            this.thdStartListen.IsBackground = true;
            this.thdStartListen.Start();
        }

        private void thdStartListenFunc()
        {
            #region
            string socketresult;
            bool issuccess = false;
            TcpSrv tcpserver = new TcpSrv(8810, this.tbConsole, 2048);
            issuccess = tcpserver.StartListen(out socketresult);

            TextBoxView.TextBoxInvoke textboxInvoke = new TextBoxView.TextBoxInvoke(TextBoxView.richTextBoxInvoke);
            textboxInvoke.BeginInvoke(this.tbConsole, socketresult, null, null);

            tcpserver.ReceiveSocket();
            #endregion
        }

        private void tsmViewClient_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            #region
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
            #endregion
        }

        private void tsmUpdateClient_Click(object sender, EventArgs e)
        {
            SendVersionFrm sndVersion = new SendVersionFrm();
            sndVersion.ShowDialog();
        }

        private void tsmGenKey_Click(object sender, EventArgs e)
        {
            GenKey genkey = new GenKey();
            genkey.ShowDialog();
        }
    }
}
