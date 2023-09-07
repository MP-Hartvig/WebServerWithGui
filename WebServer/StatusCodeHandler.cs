using System.Net.Sockets;
using System.Text;
using WebServerWithGui.Interfaces;

namespace WebServerWithGui.WebServer
{
    public class StatusCodeHandler : IStatusCodeHandler
    {
        private readonly IResponseHandler _responseHandler;

        public StatusCodeHandler(IResponseHandler responseHandler)
        {
            _responseHandler = responseHandler;
        }

        public void notImplemented(Socket clientSocket, Encoding charEncoder)
        {

            _responseHandler.sendResponse(clientSocket, "<html><head><meta http - equiv =\"Content-Type\" content=\"text/html; charset = utf - 8\">" +
                "</ head >< body >< h2 > Web server </ h2 >< div > 501 - Method Not Implemented </ div ></ body ></ html > ", 
        
                "501 Not Implemented", "text/html", charEncoder);
        }
        public void notFound(Socket clientSocket, Encoding charEncoder)
        {
            _responseHandler.sendResponse(clientSocket, "<html><head><meta http - equiv =\"Content-Type\" content=\"text/html; charset = utf - 8\">" +
                "</head><body><h2>Atasoy Simple Web Server </ h2 >< div > 404 - Not Found </ div ></ body ></ html > ", 
        
                "404 Not Found", "text/html", charEncoder);
        }

        public void sendOkResponse(Socket clientSocket, byte[] bContent, string contentType, Encoding charEncoder)
        {
            _responseHandler.sendResponse(clientSocket, bContent, "200 OK", contentType, charEncoder);
        }
    }
}
