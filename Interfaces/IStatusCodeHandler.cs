using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServerWithGui.Interfaces
{
    public interface IStatusCodeHandler
    {
        public void sendOkResponse(Socket clientSocket, byte[] bContent, string contentType, Encoding charEncoder);

        public void notFound(Socket clientSocket, Encoding charEncoder);

        public void notImplemented(Socket clientSocket, Encoding charEncoder);
    }
}
