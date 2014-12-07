using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCatTools.command
{
    class SendMsg : AbstractSendCMD
    {
        private string _userId = "";
        private string _msg = "";

        public SendMsg(string userId, string msg)
        {
            this._userId = userId;
            this._msg = msg;
        }
        protected override byte[] GetDataByte(out CommandType cmdType)
        {
            cmdType = CommandType.RecvIMInfor;
            byte[] byteAck = Encoding.UTF8.GetBytes(this._userId + ";" + this._msg + ";");
            return byteAck;
        }
    }
}
