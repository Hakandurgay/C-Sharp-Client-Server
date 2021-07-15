using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketProgramlama.Server
{

    public class Server
    {
        public static int MaxPlayers { get; private set; } //başka yerlerden değiştirilmesin diye set private
        public static int Port { get; private set; }

        public static TcpListener serverListener;

        public static SortedDictionary<int, Client> ClientsDictionary = new SortedDictionary<int, Client>();

        public static void SetupServer(int maxPlayers, int _port)
        {
            MaxPlayers = maxPlayers;
            Port = _port;
            InitializeServerData();
            serverListener = new TcpListener(IPAddress.Any, Port); //any, tüm ip adreslerinden gelen istekleri kabul eder
            Console.WriteLine($"Server kuruldu : Maksimum kullanıcı sayısı: {MaxPlayers}, Dinlenen Port: {Port}");
        }

        public static void StartServer()
        {
            int a = 5;
            serverListener.Start();
            Console.WriteLine($"Server başlatıldı {Port}'unda dinleniyor");
            serverListener.BeginAcceptTcpClient(AcceptClientCallBack, null); //biri gelince onu alır
            Console.WriteLine("Kullanıcılar bekleniyor...");
        }

        public static void AcceptClientCallBack(IAsyncResult asyncResult)
        {
            //int a = (int) asyncResult.AsyncState; //diğer metodda gönderilen a değerine bu şekilde erişiyor
            TcpClient client = serverListener.EndAcceptTcpClient(asyncResult);

            //bir client bağlandıktan sonra başka biri bağlanmak istenirse böyle döngüye alınır
            serverListener.BeginAcceptTcpClient(AcceptClientCallBack, null); //biri gelince onu alır
            Console.WriteLine($"Bir kullanıcı giriyor. {client.Client.RemoteEndPoint}");

            for (int i = 1; i <= ClientsDictionary.Count; i++)
            {
                if (ClientsDictionary[i].Tcp.socket == null)
                {
                    ClientsDictionary[i].Tcp.Connect(client);
                    return;
                }
            }
            client.Close();

            Console.WriteLine($"Bir kullanıcı içeri girdi. {client.Client.RemoteEndPoint}");
        }

        public static void InitializeServerData()
        {
            for (int i = 1; i <= MaxPlayers; i++)
            {
                ClientsDictionary.Add(i, new Client(i));
            }
        }
    }
}