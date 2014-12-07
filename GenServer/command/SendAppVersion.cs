using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenServer.command
{
    class SendAppVersion : AbstractSendCMD
    {
        private string _serverId = "";
        private string _version = "";

        public SendAppVersion(string serverId, string version)
        {
            this._serverId = serverId;
            this._version = version;
        }
        protected override byte[] GetDataByte(out CommandType cmdType)
        {
            cmdType = CommandType.RecvRequestCltVersion;
            byte[] byteAck = Encoding.UTF8.GetBytes(this._serverId + ";" + this._version + ";");
            return byteAck;
        }
    }
}
