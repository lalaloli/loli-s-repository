using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace MyPro.Net
{
    class Server
    {
        TcpClient client;
        public Net.IO.Reader reader;

        public event Action connetcedEvent;
        public event Action messageReceivedEvent;
        public event Action DisconnectedEvent;
        public Server()
        {
            client = new TcpClient();
        }

        public void ConnectToServer(String username)
        {
            if (!client.Connected)
            {
                client.Connect("127.0.0.1", 7891);
                reader = new IO.Reader(client.GetStream());
                if (!string.IsNullOrEmpty(username))
                {
                    var connect = new IO.Builder();
                    connect.WriteOpcode(0);
                    connect.WriteMessage(username);
                    client.Client.Send(connect.GetBytes());
                }
                ReadPackets();
            }
        }

        private void ReadPackets()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var opcode = reader.ReadByte();
                    switch (opcode)
                    {
                        case 1:
                            connetcedEvent?.Invoke();
                            break;

                        case 5:
                            messageReceivedEvent?.Invoke();
                            break;

                        case 10:
                            DisconnectedEvent?.Invoke();
                            break;

                        default:
                            Console.WriteLine("yes..");
                            break;
                    }
                }
            });
        }

        public void SendMessageServer(String message)
        {
            var messagePacket = new IO.Builder();
            messagePacket.WriteOpcode(5);
            messagePacket.WriteMessage(message);
            client.Client.Send(messagePacket.GetBytes());
        }
    }

}
