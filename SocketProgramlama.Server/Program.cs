using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgramlama.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //server kısmının programlamanın

            //TCP, UDP'ye göre daha güvenilirdir. Gönderilen bütün paketlerin karşı tarafa ulaştığını garanti eder. UDP etmez. Örneğin bir web üzerinden  görüntülü konuşma yapılacak olsun. Aradaki görüntü kayıpları udp sayesinde tolere edilerek efordan kazanç sağlanabilir.

            //TCP paketleri 1500bytelık paketlere böler, network üzerinde portları ayarlar, sesion kontrolü yapar, congestion (tıkanıklık) kontrolü yapar. örneğin bant genişliğinden daha fazla veri gönderilirse hızı yavaşlatarak bunu ayarlar
            Server.SetupServer(500, 8585);

            Server.StartServer();

            Console.ReadKey();
        }
    }
}
