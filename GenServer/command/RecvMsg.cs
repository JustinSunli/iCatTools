using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenServer.command
{
    class RecvMsg : AbstractRecvCMD
    {
        public RecvMsg(byte[] dataBuffer)
        {
            this._dataBuffer = dataBuffer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <returns></returns>
        public override byte[] returnAck(bool isSuccess, out string strView)
        {
            #region
            string consoleViewFormat = "用户[{0}]发送消息：{1}。";
            int infLen = this._dataBuffer.Length-6;
            byte[] byteAck = null;
            byte[] infArr = new byte[infLen];
            Array.Copy(this._dataBuffer, 4, infArr, 0, infLen);
            string[] dataArr = System.Text.Encoding.UTF8.GetString(infArr).Split(';');
            strView = string.Format(consoleViewFormat, dataArr[0], dataArr[1]);
            return byteAck;
            #endregion
        }
    }
}
