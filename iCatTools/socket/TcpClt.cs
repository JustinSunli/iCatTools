using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using GenDataLibrary;
using System.IO;
using System.Data;
using iCatTools.command;
using iCatTools.common;
using iCatTools.Frm;

namespace iCatTools.socket
{
    class TcpClt
    {
        private AppParamsData appParamsData = new AppParamsData();
        private string _serverIp = "";
        private int _serverPort = 8818;
        private DateTime _updateTime = new DateTime();
        /// <summary>
        /// 连接服务器并发送指令数据
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="msgByte"></param>
        /// <returns></returns>
        public bool ConnectSrvAndSend(string ip, int port, byte[] msgByte,ref int sendCount)
        {
            #region
            Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPEndPoint ServerInfo = new IPEndPoint(IPAddress.Parse(ip), port);
                ClientSocket.Connect(ServerInfo);
                sendCount = ClientSocket.Send(msgByte);
                if (sendCount > 0)
                {
                    this._updateTime = DateTime.Now; //此处应该获取服务器的当前时间
                    this._serverIp = ip;
                    this._serverPort = port;
                    MainForm._srvIp = ip;
                    MainForm._srvPort = port;
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                ClientSocket.Close();
                ClientSocket.Dispose();
            }
            #endregion
        }
        /// <summary>
        /// 开始测试连接
        /// </summary>
        /// <param name="xmlFile"></param>
        public void TestConnectSrv()
        {
            #region
            AbstractSendCMD sendCmd = new SendBeat(ApplicationBase.KeyUser);
            while (this._serverIp == string.Empty)
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                Stream manifestResourceStream = null;
                manifestResourceStream = asm.GetManifestResourceStream("iCatTools.AppParams.xml");
                appParamsData.ReadXml(manifestResourceStream, XmlReadMode.Auto);
                DataRow srvInforDr = null;
                string ipAddr = "";
                int port = 8818;
                for (int i = 0; i < appParamsData.Tables[0].Rows.Count; i++)
                {
                    srvInforDr = appParamsData.Tables[0].Rows[i];
                    int sndByteCount = 0;
                    ipAddr = srvInforDr[AppParamsData.IpAddress].ToString();
                    port = Convert.ToInt32(srvInforDr[AppParamsData.Port]);

                    CommandFactory commandfactory = new CommandFactory(sendCmd);
                    this.ConnectSrvAndSend(ipAddr, port, commandfactory.GetCommand(), ref sndByteCount);

                    if (sndByteCount > 0)
                        break;
                }
                Thread.Sleep(60000);
            }
            while (true)
            {
                int sndByteCount = 0;
                CommandFactory commandfactory = new CommandFactory(sendCmd);
                this.ConnectSrvAndSend(this._serverIp, this._serverPort, commandfactory.GetCommand(), ref sndByteCount);
                Thread.Sleep(60000);
            }
            #endregion
        }
    }
}
