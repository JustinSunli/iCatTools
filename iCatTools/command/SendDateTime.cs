using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPerCollect.common;
using BaseInfoBusinessLayer;

namespace GenServer.command
{
    class SendCMDDateTime : AbstractSendCMD
    {
        public string _destBaseStation = "";
        public SendCMDDateTime(string destBaseStation)
        {
            this._destBaseStation = destBaseStation;
        }
        protected override byte[] GetDataByte(out CommandType cmdType)
        {
            cmdType = CommandType.RequestTime;
            byte[] byteAck;
            byte[] destBaseStation;
            destBaseStation = System.Text.Encoding.ASCII.GetBytes(_destBaseStation);
            int i = 0;
            if (!ApplicationBase.IsAllTcp)
            {
                byteAck = new byte[10];
                foreach (byte c in destBaseStation)
                    byteAck[i++] = c;
                DateTime nowtime = BusinessCommon.GetCurrentDateTime();
                byteAck[i++] = (byte)(((nowtime.Year - 2000) / 10) * 16 + (nowtime.Year % 10));
                byteAck[i++] = (byte)((nowtime.Month / 10 * 16) + nowtime.Month % 10);
                byteAck[i++] = (byte)((nowtime.Day / 10 * 16) + nowtime.Day % 10);
                byteAck[i++] = (byte)((nowtime.Hour / 10 * 16) + nowtime.Hour % 10);
                byteAck[i++] = (byte)((nowtime.Minute / 10 * 16) + nowtime.Minute % 10);
                byteAck[i++] = (byte)((nowtime.Second / 10 * 16) + nowtime.Second % 10);
            }
            else
            {
                byteAck = new byte[6];
                DateTime nowtime = BusinessCommon.GetCurrentDateTime();
                byteAck[i++] = (byte)(((nowtime.Year - 2000) / 10) * 16 + (nowtime.Year % 10));
                byteAck[i++] = (byte)((nowtime.Month / 10 * 16) + nowtime.Month % 10);
                byteAck[i++] = (byte)((nowtime.Day / 10 * 16) + nowtime.Day % 10);
                byteAck[i++] = (byte)((nowtime.Hour / 10 * 16) + nowtime.Hour % 10);
                byteAck[i++] = (byte)((nowtime.Minute / 10 * 16) + nowtime.Minute % 10);
                byteAck[i++] = (byte)((nowtime.Second / 10 * 16) + nowtime.Second % 10);
            }
            return byteAck;
        }
    }
}
