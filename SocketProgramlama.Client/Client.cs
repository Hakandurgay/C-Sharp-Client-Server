using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgramlama.Client
{
    public class Client
    {
        public static TcpClient socket = new TcpClient();

        public static void Connect()
        {

            socket.BeginConnect(ServerSettings.Host, ServerSettings.Port, new AsyncCallback(ConnectCallBack), null);
            Console.WriteLine("Bağlanılıyor");
        }

        public static void ConnectCallBack(IAsyncResult asyncResult)
        {
            socket.EndConnect(asyncResult);
            if (socket.Connected)
                Console.WriteLine("Bağlanıldı");
        }
    }
}
