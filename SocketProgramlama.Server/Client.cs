using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgramlama.Server
{
    public class Client
    {
        public int id { get; set; }
        public TCP Tcp;
        public Client(int _id)
        {
            id = _id;
            Tcp = new TCP(id);
        }

        public class TCP
        {
            public readonly int id;
            public TcpClient socket;
            public TCP(int _id)
            {
                id = _id;
            }

            public void Connect(TcpClient _socket)
            {
                socket = _socket;
                Console.WriteLine($"Bağlantı gerçekleştirildi: {id}");
            }
        }
    }
}