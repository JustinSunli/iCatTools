using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iCatTools.socket;
using System.Threading;
using iCatTools.common;

namespace iCatTools.Frm
{
    public partial class MainForm
    {
        private Thread _thdConnectSrv = null;
        private Thread _thdListenSocket = null;
        /// <summary>
        /// 服务端IP
        /// </summary>
        public static string _srvIp = "";
        /// <summary>
        /// 服务端端口
        /// </summary>
        public static int _srvPort = 8818;
        /// <summary>
        /// 开启后台线程
        /// </summary>
        private void StartBckThread()
        {
            #region
            TcpClt tcpclient = new TcpClt();
            this._thdConnectSrv = new Thread(new ThreadStart(tcpclient.TestConnectSrv));
            this._thdConnectSrv.IsBackground = true;
            this._thdConnectSrv.Start();
            TcpSrv tcpserver = new TcpSrv(1010, 4096);
            this._thdListenSocket = new Thread(new ThreadStart(thdStartListenFunc));
            this._thdListenSocket.IsBackground = true;
            this._thdListenSocket.Start();
            #endregion
        }
        /// <summary>
        /// 服务端开启侦听
        /// </summary>
        private void thdStartListenFunc()
        {
            #region
            string socketresult;
            bool issuccess = false;
            TcpSrv tcpserver = new TcpSrv(1010, 4096);
            issuccess = tcpserver.StartListen(out socketresult);
            if (!issuccess)
            {
                MessageBase.ShowError("不能启动两个客户端！");
                this.nIconSystem.Visible = false;
                System.Environment.Exit(0);
                return;
            }
            tcpserver.ReceiveSocket();
            #endregion
        }

    }
}
