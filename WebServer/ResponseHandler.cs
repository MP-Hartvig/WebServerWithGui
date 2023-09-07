using WebServerWithGui.Interfaces;
using System.Net.Sockets;
using System.Text;

namespace WebServerWithGui.WebServer
{
    public class ResponseHandler : IResponseHandler
    {
        private readonly IExceptionHandler _exceptionHandler;

        public ResponseHandler(IExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        // For strings
        public void sendResponse(Socket clientSocket, string strContent, string responseCode, string contentType, Encoding charEncoder)
        {
            byte[] bContent = charEncoder.GetBytes(strContent);
            sendResponse(clientSocket, bContent, responseCode, contentType, charEncoder);
        }

        // For byte arrays
        public void sendResponse(Socket clientSocket, byte[] bContent, string responseCode, string contentType, Encoding charEncoder)
        {
            try
            {
                byte[] bHeader = charEncoder.GetBytes(
                                    "HTTP/1.1 " + responseCode + "\r\n"
                                  + "Server: Atasoy Simple Web Server\r\n"
                                  + "Content-Length: " + bContent.Length.ToString() + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
                clientSocket.Send(bHeader);
                clientSocket.Send(bContent);
                clientSocket.Close();
            }
            catch(Exception ex) 
            {
                _exceptionHandler.HandleException(ex);
            }
        }
    }
}
