using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServers.Net.IO
{
    class Builder
    {
        MemoryStream ms;

        public Builder()
        {
            ms = new MemoryStream();

        }
        public void WriteOpcode(byte opcode)
        {
            ms.WriteByte(opcode);
        }

        public void WriteMessage(string msg)
        {
            var msgLenght = msg.Length;
            ms.Write(BitConverter.GetBytes(msgLenght));
            ms.Write(Encoding.ASCII.GetBytes(msg));
        }

        public byte[] GetBytes()
        {
            return ms.ToArray();
        }
    }
}
