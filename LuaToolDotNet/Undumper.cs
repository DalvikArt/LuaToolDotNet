using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LuaToolDotNet
{
    public class Undumper
    {
        readonly string FileName = "";

        byte[] buffer;
        int offset = 0;

        public Undumper(string fileName)
        {
            FileName = fileName;

            FileStream fsBytecode = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            buffer = new byte[fsBytecode.Length];
            fsBytecode.Read(buffer, 0, buffer.Length);

            fsBytecode.Close();
        }

        public byte LoadByte()
        {
            return buffer[offset++];
        }

        public int LoadInt()
        {
            int result = ((int)buffer[offset++]) ;
            result += ((int)buffer[offset++]) << 8;
            result += ((int)buffer[offset++]) << 16;
            result += ((int)buffer[offset++]) << 24;

            return result;
        }

        public uint LoadUInt()
        {
            uint result = ((uint)buffer[offset++]) ;
            result += ((uint)buffer[offset++]) << 8;
            result += ((uint)buffer[offset++]) << 16;
            result += ((uint)buffer[offset++]) << 24;

            return result;
        }

        public byte[] LoadBlock(int length)
        {
            byte[] result = buffer.Skip(offset).Take(length).ToArray();
            offset += length;

            return result;
        }

        public string LoadString()
        {
            int length = LoadInt();

            string result = Encoding.ASCII.GetString(buffer.Skip(offset).Take((int)length).ToArray());
            offset += (int)length;

            return result;
        }
    }
}
