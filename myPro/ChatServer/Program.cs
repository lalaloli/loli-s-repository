using ChatServer;
using System;
using System.Net;
using System.Net.Sockets;

namespace ChatServers
{
    class Program
    {
        static List<Client> users;
        static TcpListener listener;
        static void Main(string[] args)
        {
            users = new List<Client>();
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7891);
            listener.Start();
            while (true)
            {
                var client = new Client(listener.AcceptTcpClient());
                users.Add(client);
                BroadcastConnection();
            }//多人链接


        }

        static void BroadcastConnection()
        {
            foreach (var user in users)
            {
                foreach (var u in users)
                {
                    var broadcostPacket = new ChatServer.Net.IO.Builder();
                    broadcostPacket.WriteOpcode(1);
                    broadcostPacket.WriteMessage(u.UserName);
                    broadcostPacket.WriteMessage(u.UId.ToString());
                    user.ClientSocket.Client.Send(broadcostPacket.GetBytes());
                }
            }
        }

        public static void BroadcastMessage(String maeeage)
        {
            foreach (var user in users)
            {
                var msgPacket = new ChatServer.Net.IO.Builder();
                msgPacket.WriteOpcode(5);
                msgPacket.WriteMessage(maeeage);
                user.ClientSocket.Client.Send(msgPacket.GetBytes());
            }

        }

        public static void BroadcastDiconnect(String uid)
        {
            var disconnectedUser = users.Where(x => x.UId.ToString() == uid).FirstOrDefault();
            users.Remove(disconnectedUser);
            foreach (var user in users)
            {
                var broadcastPacket = new ChatServer.Net.IO.Builder();
                broadcastPacket.WriteOpcode(10);
                broadcastPacket.WriteMessage(uid);
                user.ClientSocket.Client.Send(broadcastPacket.GetBytes());
            }
            BroadcastMessage($"[{disconnectedUser.UserName}] Disconnected!");

        }
    }


}
