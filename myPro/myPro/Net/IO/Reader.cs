using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Net.IO
{

        internal class Reader : BinaryReader
        {

            private NetworkStream _ns;
            public Reader(NetworkStream ns) : base(ns)
            {
                _ns = ns;
            }

            public string ReadMeaasge()
            {
                byte[] MessageBuffer;
                var length = ReadInt32();
                MessageBuffer = new byte[length];
                _ns.Read(MessageBuffer, 0, length);

                var msg = Encoding.UTF8.GetString(MessageBuffer);

                return msg;
            }


        }
    
}
