using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using GenServer.command;

namespace GenServer.socket
{
    class TcpSrv
    {
        /// <summary>
        /// 公开网络端口
        /// </summary>
        private int _port;
        /// <summary>
        /// 侦听地址
        /// </summary>
        private IPAddress _serverIp = Dns.GetHostAddresses(Dns.GetHostName())[0];
        /// <summary>
        /// 服务器端的监听器
        /// </summary>
        private TcpListener _tcpl = null;
        private TextBox _console = null;
        private byte[] _recvDataBuffer;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="port"></param>
        /// <param name="console"></param>
        /// <param name="bufLength"></param>
        public TcpSrv(int port, object console, int bufLength)
        {
            #region
            this._port = port;
            this._console = (TextBox)console;
            this._recvDataBuffer = new byte[bufLength];
            #endregion
        }
        /// <summary>
        /// 开始侦听方法
        /// </summary>
        /// <param name="socketResult"></param>
        /// <returns></returns>
        public bool StartListen(out string socketResult)
        {
            #region
            try
            {
                IPAddress _ip = Dns.GetHostAddresses(Dns.GetHostName())[0];
                _tcpl = new TcpListener(_ip, _port);
                _tcpl.Start(1);
                socketResult = string.Format("服务器已启动，正在侦听...\r\n服务器IP：{0}\t端口号：{1}\r\n\r\n", this._serverIp, this._port);
                return true;
            }
            catch (Exception e)
            {
                socketResult = e.ToString() + "\r\n";
                return false;
            }
            #endregion
        }
        /// <summary>
        /// 从客户端接收数据
        /// </summary>
        public void ReceiveSocket()
        {
            #region
            try
            {
                _tcpl.Server.BeginAccept(new AsyncCallback(AcceptConn), _tcpl.Server);
            }
            catch (Exception e)
            {
                throw;
                //ApplicationBase.WriteLog(e.ToString());
            }
            #endregion
        }
        /// <summary>
        /// 异步接收数据
        /// </summary>
        /// <param name="iar"></param>
        private void AcceptConn(IAsyncResult iar)
        {
            #region
            try
            {
                Socket oldserver = (Socket)iar.AsyncState;
                Socket client = oldserver.EndAccept(iar);

                _tcpl.Server.BeginAccept(new AsyncCallback(AcceptConn), _tcpl.Server);
                client.BeginReceive(_recvDataBuffer, 0, _recvDataBuffer.Length, SocketFlags.None,
                            new AsyncCallback(ReceiveData), client);
            }
            catch (Exception e)
            {
                throw;
                //ApplicationBase.WriteLog(e.ToString());
            }
            #endregion
        }
        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="iar"></param>
        private void ReceiveData(IAsyncResult iar)
        {
            #region
            Socket client = (Socket)iar.AsyncState;
            IPAddress clientIp = ((System.Net.IPEndPoint)client.RemoteEndPoint).Address;
            TextBoxView.TextBoxInvoke textboxInvoke = new TextBoxView.TextBoxInvoke(TextBoxView.richTextBoxInvoke);
            string[] viewArr = new string[4];
            try
            {
                byte[] data;
                string dataX2 = "";
                int recvCount = client.EndReceive(iar);
                if (recvCount == 0)
                {
                    client.Close();
                    return;
                }
                else if (recvCount > 0)
                {
                    data = new byte[recvCount];
                    Buffer.BlockCopy(_recvDataBuffer, 0, data, 0, recvCount);
                    for (int i = 0; i < recvCount; i++)
                    {
                        //data[i] = _recvDataBuffer[i];
                        dataX2 += data[i].ToString("X2");
                    }
                    CommandFactory resolvecmd = new CommandFactory(data);
                    resolvecmd.SaveCommand(this._console);

                    //textboxInvoke.BeginInvoke(this._console, "[" + DateTime.Now.ToString() + "]" + dataX2, null, null);
                }
                client.BeginReceive(_recvDataBuffer, 0, _recvDataBuffer.Length, SocketFlags.None,
                        new AsyncCallback(ReceiveData), client);
            }
            catch (Exception e)
            {
                throw;
                //ApplicationBase.WriteLog(e.ToString());
            }
            #endregion
        }
    }
}
