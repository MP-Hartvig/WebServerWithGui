using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServerWithGui.Interfaces
{
    public interface IResponseHandler
    {
        public void sendResponse(Socket clientSocket, string strContent, string responseCode,
                                  string contentType, Encoding charEncoder);
        public void sendResponse(Socket clientSocket, byte[] bContent, string responseCode,
                          string contentType, Encoding charEncoder);
    }
}
