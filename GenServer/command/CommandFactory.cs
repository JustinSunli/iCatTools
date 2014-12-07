/****************************************
###创建人：bhlfy
###创建时间：2011-08-21
###公司：博华科技
###最后修改时间：2011-08-21
###最后修改人：bhlfy
###修改摘要：
****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using GenServer.socket;

namespace GenServer.command
{
    public class CommandFactory
    {
        private byte[] _recvDataBuffer;
        //private byte[] _sendDataBuffer;
        private AbstractRecvCMD _commandRecv;
        private AbstractSendCMD _commandSend;
        private Hashtable _cmdHashTb;
        //private 
        public CommandFactory(byte[] dataBuffer)
        {
            this._recvDataBuffer = dataBuffer;
            this._cmdHashTb = new Hashtable();
        }

        public CommandFactory(AbstractSendCMD commandSend)
        {
            this._commandSend = commandSend;
        }
        /// <summary>
        /// 比较数组各值
        /// </summary>
        /// <param name="leftArr"></param>
        /// <param name="rightArr"></param>
        /// <returns></returns>
        private bool EqualByteArray(byte[] leftArr, byte[] rightArr)
        {
            #region
            if (leftArr.Length != rightArr.Length)
                return false;
            for (int i = 0; i < leftArr.Length; i++)
            {
                if (leftArr[i] != rightArr[i])
                    return false;
            }
            return true;
            #endregion
        }
        /// <summary>
        /// 处理命令
        /// </summary>
        public void SaveCommand(object console)
        {
            #region
            //hashResponseByte = new Hashtable();
            byte[] cmdTempArr;
            byte[] responseByte; //交互返回信息
            string consoleView = ""; //控制台显示信息
            int htIndex = 0; //一次性获取信息中会包括多个0x03...0x13的实体信息，该值为其索引
            int dataIndex = 0, sigIndex = 0; //sigIndex为单条信息的字节索引
            byte[] cmdDecodeArr;
            this._cmdHashTb.Clear();
            TextBoxView.TextBoxInvoke textboxInvoke = new TextBoxView.TextBoxInvoke(TextBoxView.richTextBoxInvoke);
            try
            {
                while (true)
                {
                    //解析得考虑之前asc码转字节数据的步骤
                    if (dataIndex == this._recvDataBuffer.Length)
                        break;
                    if (this._recvDataBuffer[dataIndex] == 0x13)
                    {
                        cmdTempArr = new byte[sigIndex + 1];
                        Array.Copy(this._recvDataBuffer, dataIndex - sigIndex, cmdTempArr, 0, sigIndex + 1);
                        this._cmdHashTb.Add(htIndex + 1, cmdTempArr);
                        htIndex++;
                        sigIndex = 0;
                    }
                    sigIndex++;
                    dataIndex++;
                }
                foreach (DictionaryEntry sigInfor in _cmdHashTb)
                {
                    cmdTempArr = sigInfor.Value as byte[];
                    cmdDecodeArr = this.getByteCode(cmdTempArr, 1, cmdTempArr.Length);
                    CommandType commandtype = (CommandType)cmdDecodeArr[1];
                    switch (commandtype)
                    {

                        case CommandType.RecvBeat: //获取心跳连接包
                            {
                                this._commandRecv = new RecvBeat(cmdDecodeArr);
                                break;
                            }
                        case CommandType.RecvIMInfor: 
                            {
                                this._commandRecv = new RecvMsg(cmdDecodeArr);
                                break;
                            }
                        default:
                            {
                                //this._commandRecv = new RecvCMDNotUse(cmdTempArr);
                                break;
                            }
                    }
                    this._commandRecv.SaveCommand(out responseByte, out consoleView);
                    textboxInvoke.BeginInvoke(console, "[" + DateTime.Now.ToString() + "]" + consoleView, null, null);
                    //构造返回指令，并存入hashtable
                    if (responseByte != null)
                    {
                        responseByte = AbstractSendCMD.CreateSendCMD(commandtype, responseByte);
                    }
                }
            }
            catch
            {
                throw;
            }
            #endregion
        }
        private byte[] getByteCode(byte[] source, int startDeIndex, int len)
        {
            byte[] dest = new byte[len-3];
            dest[0] = source[0];
            for (int i = startDeIndex; i < 7; i++)
            {
                if (i % 2 == 0)
                {
                    byte xtmp = 0x00;
                    byte ytmp = 0x00;
                    if (source[i - 1] <= 0x39)
                    {
                        xtmp = (byte)(source[i - 1] - 0x30);
                        ytmp = (byte)(source[i] - 0x30);
                    }
                    else
                    {
                        xtmp = (byte)(source[i - 1] - 0x37);
                        ytmp = (byte)(source[i] - 0x37);
                    }
                    xtmp = (byte)(xtmp << 4);
                    dest[i / 2] = (byte)(xtmp + ytmp);
                }
            }
            for (int i = 0; i < len - 7; i++)
            {
                dest[i+4] = source[i+7];
            }
            return dest;
        }

        public byte[] GetCommand() 
        {
            return _commandSend.GetSendCMDByte();
        }

        public ArrayList GetCommandHash() {
            byte[] b1 = new byte[3];
            byte[] b2 = new byte[4];

            ArrayList arr = new ArrayList();
            arr.Add(b1);
            arr.Add(b2);
            Hashtable ht = new Hashtable();
            ht.Add(1, b1);
            byte[] b3 = ht[1] as byte[];
            return arr;
        }
    }
}
