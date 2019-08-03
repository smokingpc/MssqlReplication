using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWriteTool
{
    internal enum APP_STATE
    {
        STOPPED = 0,
        RUNNING = 1,
    }

    internal enum DB_CONN_TYPE
    {
        [Description("Localhost Share Memory")]
        SHARE_MEM = 0,
        [Description("Network: TCP/IP")]
        TCPIP = 1,
    }

}
