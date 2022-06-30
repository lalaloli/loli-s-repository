using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net
{
    class Server
    {
        TcpClient New_client;

        public Server()
        {
            New_client = new TcpClient();
        }

        public void ConnectToServer()
        {
            if (New_client.Connected)
            {
                New_client.Connect("127.0.0.1", 7891);
            }
        }
    }
}
