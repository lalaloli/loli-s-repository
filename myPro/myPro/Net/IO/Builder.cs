using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Net.IO
{
    internal class Builder
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
            var msgLenght = Encoding.UTF8.GetBytes(msg).Length;
            ms.Write(BitConverter.GetBytes(msgLenght));
            ms.Write(Encoding.UTF8.GetBytes(msg));
        }

        public byte[] GetBytes()
        {
            return ms.ToArray();
        }
    }
}
