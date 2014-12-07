using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCatTools.command
{
    class SendBeat : AbstractSendCMD
    {
        private string _userId = "";
        public SendBeat(string userId)
        {
            this._userId = userId;
        }
        protected override byte[] GetDataByte(out CommandType cmdType)
        {
            cmdType = CommandType.RecvBeat;
            byte[] byteAck = Encoding.UTF8.GetBytes(this._userId+";connect;");
            return byteAck;
        }
    }
}
