using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServerWithGui.Interfaces
{
    public interface IServer
    {
        public bool StartServer(IPAddress ipAddress, int port, int maxNOfCon, string contentPath, Encoding charEncoder);

        public void StopServer();
    }
}
