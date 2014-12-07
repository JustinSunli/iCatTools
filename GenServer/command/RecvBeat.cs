using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenServer.command
{
    class RecvBeat : AbstractRecvCMD
    {
        public RecvBeat(byte[] dataBuffer)
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
            string consoleViewFormat = "用户[{0}]请求连接。";
            int infLen = this._dataBuffer.Length-6;
            byte[] byteAck = null;
            byte[] infArr = new byte[infLen];
            Array.Copy(this._dataBuffer, 4, infArr, 0, infLen);
            string[] dataArr = System.Text.Encoding.UTF8.GetString(infArr).Split(';');
            strView = string.Format(consoleViewFormat, dataArr[0]);
            return byteAck;
            #endregion
        }
    }
}
