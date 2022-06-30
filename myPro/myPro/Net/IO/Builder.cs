using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPro.Net.IO
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
            //ms.Write(BitConverter.GetBytes(msgLenght));
            //ms.Write(Encoding.ASCII.GetBytes(msg));
            ms.Write(Encoding.ASCII.GetBytes(msg), 0, msgLenght);
        }

        public byte[] GetBytes()
        {
            return ms.ToArray();
        }
    }
}
