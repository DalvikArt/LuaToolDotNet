using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LuaToolDotNet
{
    class Debugger
    {
        Socket socket = null;

        public Debugger()
        {

        }

        public bool ConnectToDebugee(string host, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);

            if (ipHostInfo.AddressList.Length == 0)
                return false;

            IPEndPoint endPoint = new IPEndPoint(ipHostInfo.AddressList[0], port);

            socket = new Socket(ipHostInfo.AddressList[0].AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(endPoint);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }

            return true;
        }

    }
}
