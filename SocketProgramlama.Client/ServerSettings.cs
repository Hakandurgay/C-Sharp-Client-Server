using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgramlama.Client
{
    public class ServerSettings
    {
        public static string Host { get; set; }
        public static int Port { get; set; }

        public static void SetServer(string _host, int _port)
        {
            Host = _host;
            Port = _port;
        }

    }
}
