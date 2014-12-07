using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCatTools.command
{
    class SendRequestVersion : AbstractSendCMD
    {
        private string _userId = "";
        public SendRequestVersion(string userId)
        {
            this._userId = userId;
        }
        protected override byte[] GetDataByte(out CommandType cmdType)
        {
            cmdType = CommandType.RecvRequestCltVersion;
            byte[] byteAck = Encoding.UTF8.GetBytes(this._userId + ";version;");
            return byteAck;
        }
    }
}
