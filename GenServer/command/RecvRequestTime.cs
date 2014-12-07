using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersonnelLocateBusinessLayer;
using iPerCollect.common;
using BaseInfoBusinessLayer;

namespace GenServer.command
{
    class RecvCMDRequestTime : AbstractRecvCMD
    {
        public RecvCMDRequestTime(byte[] dataBuffer)
        {
            this._dataBuffer = dataBuffer;
        }

        protected override bool ValidateLength()
        {
            return base.ValidateLength();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <returns></returns>
        public override byte[] returnAck(bool isSuccess)
        {
            #region
            byte[] byteAck;
            if (!ApplicationBase.IsAllTcp)
            {
                byteAck = new byte[10];
                byteAck[0] = this._dataBuffer[4];
                byteAck[1] = this._dataBuffer[5];
                byteAck[2] = this._dataBuffer[6];
                byteAck[3] = this._dataBuffer[7];
                DateTime nowtime = BusinessCommon.GetCurrentDateTime();
                byteAck[4] = (byte)(((nowtime.Year - 2000) / 10) * 16 + (nowtime.Year % 10));
                byteAck[5] = (byte)((nowtime.Month / 10 * 16) + nowtime.Month % 10);
                byteAck[6] = (byte)((nowtime.Day / 10 * 16) + nowtime.Day % 10);
                byteAck[7] = (byte)((nowtime.Hour / 10 * 16) + nowtime.Hour % 10);
                byteAck[8] = (byte)((nowtime.Minute / 10 * 16) + nowtime.Minute % 10);
                byteAck[9] = (byte)((nowtime.Second / 10 * 16) + nowtime.Second % 10);
            }
            else
            {
                byteAck = new byte[6];
                DateTime nowtime = BusinessCommon.GetCurrentDateTime();
                byteAck[0] = (byte)(((nowtime.Year - 2000) / 10) * 16 + (nowtime.Year % 10));
                byteAck[1] = (byte)((nowtime.Month / 10 * 16) + nowtime.Month % 10);
                byteAck[2] = (byte)((nowtime.Day / 10 * 16) + nowtime.Day % 10);
                byteAck[3] = (byte)((nowtime.Hour / 10 * 16) + nowtime.Hour % 10);
                byteAck[4] = (byte)((nowtime.Minute / 10 * 16) + nowtime.Minute % 10);
                byteAck[5] = (byte)((nowtime.Second / 10 * 16) + nowtime.Second % 10);
            }
            if (isSuccess)
                return byteAck;
            else
                return null;
            #endregion
        }
    }
}
