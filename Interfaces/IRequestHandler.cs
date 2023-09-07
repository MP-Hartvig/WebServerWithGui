using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServerWithGui.Interfaces
{
    public interface IRequestHandler
    {
        public void HandleTheRequest(Socket clientSocket, string contentPath, Encoding charEncoder);
    }
}
