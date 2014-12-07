using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iCatTools.common;
using System.Windows.Forms;

namespace iCatTools.command
{
    class RecvVersion : AbstractRecvCMD
    {
        public RecvVersion(byte[] dataBuffer)
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
            int infLen = this._dataBuffer.Length - 6;
            byte[] byteAck = null;
            byte[] infArr = new byte[infLen];
            Array.Copy(this._dataBuffer, 4, infArr, 0, infLen);
            string[] dataArr = System.Text.Encoding.UTF8.GetString(infArr).Split(';');
            //strView = string.Format(consoleViewFormat, dataArr[0], dataArr[1]);
            if (ApplicationBase.ApplicationVersion != dataArr[1])
            {
                if (MessageBase.ShowConfirm("您的版本已过期，请点击确认更新！") == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(Application.StartupPath+"\\GenAutoUpdate.exe");
                    System.Environment.Exit(0);
                }
            }
            strView = "";
            return byteAck;
            #endregion
        }
    }
}
