using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgramlama.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerSettings.SetServer("127.0.0.1",8585);
            Client.Connect();
            Console.ReadKey();
        }
    }
}
