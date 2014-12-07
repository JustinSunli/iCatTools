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

namespace GenServer.command
{
    public enum CommandType
    {
        RecvBeat = 0x10,
        RecvRequestCltVersion = 0x11,
        RecvIMInfor = 0x12,
        NotUse = 0x99
    }
}
