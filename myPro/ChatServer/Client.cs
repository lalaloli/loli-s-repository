using ChatServers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    internal class Client
    {
        public string UserName { get; set; }
        public Guid UId { get; set; }
        public TcpClient ClientSocket { get; set; }

        Net.IO.Reader reader;
        public Client(TcpClient client)
        {
            ClientSocket = client;
            UId = Guid.NewGuid();
            reader = new Net.IO.Reader(ClientSocket.GetStream());

            var opcode = reader.ReadByte();
            UserName = reader.ReadMeaasge();


            Console.WriteLine($"[{DateTime.Now}]:Client has connected with the username :{UserName}");

            Task.Run(() => Process());
        }
        void Process()
        {
            while (true)
            {
                try
                {
                    var opcode = reader.ReadByte();
                    switch (opcode)
                    {
                        case 5:
                            var msg = reader.ReadMeaasge();
                            Console.WriteLine($"[{DateTime.Now}]: Message received!{msg}");
                            Program.BroadcastMessage($"[{DateTime.Now}]:[{UserName}]:{msg}");
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{UId.ToString()}]: Disconnected!");
                    Program.BroadcastDiconnect(UId.ToString());
                    ClientSocket.Close();
                    break;
                }
            }
        }
    }
}
