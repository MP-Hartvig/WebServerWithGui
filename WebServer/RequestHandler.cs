using WebServerWithGui.Interfaces;
using System.Net.Sockets;
using System.Text;

namespace WebServerWithGui.WebServer
{
    public class RequestHandler : IRequestHandler
    {
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IStatusCodeHandler _statusCodeHandler;
        private Dictionary<string, string> extensions = new Dictionary<string, string>()
        { 
            //{ "extension", "content type" }
            { "htm", "text/html" },
            { "html", "text/html" },
            { "xml", "text/xml" },
            { "txt", "text/plain" },
            { "css", "text/css" },
            { "png", "image/png" },
            { "gif", "image/gif" },
            { "jpg", "image/jpg" },
            { "jpeg", "image/jpeg" },
            { "zip", "application/zip"}
        };

        public RequestHandler(IExceptionHandler exceptionHandler, IStatusCodeHandler statusCodeHandler)
        {
            _exceptionHandler = exceptionHandler;
            _statusCodeHandler = statusCodeHandler;
        }

        public void HandleTheRequest(Socket clientSocket, string contentPath, Encoding charEncoder)
        {
            string strReceived = GetSocketBufferString(clientSocket, charEncoder);

            // Get the request type (GET/POST)
            string httpMethod = strReceived.Substring(0, strReceived.IndexOf(" "));

            // Check if valid request type
            if (!httpMethod.Equals("GET") || !httpMethod.Equals("POST"))
            {
                _statusCodeHandler.notImplemented(clientSocket, charEncoder);
                return;
            }

            // Get the requested url
            int start = strReceived.IndexOf(httpMethod) + httpMethod.Length + 1;
            int length = strReceived.LastIndexOf("HTTP") - start - 1;
            string requestedUrl = strReceived.Substring(start, length);

            string requestedFile;

            requestedFile = requestedUrl.Split('?')[0].Replace("/", @"\").Replace("\\..", "");
            start = requestedFile.LastIndexOf('.') + 1;
            DecideResponseType(start, length, requestedFile, contentPath, clientSocket, charEncoder);
        }

        private string GetSocketBufferString(Socket clientSocket, Encoding charEncoder)
        {
            byte[] buffer = new byte[10240];
            int receivedBCount = clientSocket.Receive(buffer);
            return charEncoder.GetString(buffer, 0, receivedBCount);
        }

        private void DecideResponseType(int start, int length, string requestedFile, string contentPath, Socket clientSocket, Encoding charEncoder)
        {
            if (start > 0)
            {
                try
                {
                    length = requestedFile.Length - start;
                    string extension = requestedFile.Substring(start, length);

                    if (!extensions.ContainsKey(extension))
                    {
                        throw new ArgumentException();
                    }

                    if (File.Exists(contentPath + requestedFile))
                    {
                        _statusCodeHandler.sendOkResponse(clientSocket, File.ReadAllBytes(contentPath + requestedFile), extensions[extension], charEncoder);
                    }
                    else
                    {
                        _statusCodeHandler.notFound(clientSocket, charEncoder);
                    }
                }
                catch (Exception ex)
                {
                    _exceptionHandler.HandleException(ex);
                }
            }
            else
            {
                try
                {
                    // If file is not specified try to send index.htm or index.html
                    if (requestedFile.Substring(length - 1, 1) != @"\")
                        requestedFile += @"\";
                    if (File.Exists(contentPath + requestedFile + "index.htm"))
                        _statusCodeHandler.sendOkResponse(clientSocket,
                          File.ReadAllBytes(contentPath + requestedFile + "\\index.htm"), "text/html", charEncoder);
                    else if (File.Exists(contentPath + requestedFile + "index.html"))
                        _statusCodeHandler.sendOkResponse(clientSocket,
                          File.ReadAllBytes(contentPath + requestedFile + "\\index.html"), "text/html", charEncoder);
                    else
                        _statusCodeHandler.notFound(clientSocket, charEncoder);
                }
                catch (Exception ex)
                {
                    _exceptionHandler.HandleException(ex);
                }
            }
        }
    }
}
