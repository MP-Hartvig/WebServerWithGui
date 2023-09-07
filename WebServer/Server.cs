using WebServerWithGui.Interfaces;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace WebServerWithGui.WebServer
{
    public class Server : IServer
    {
        public bool running = false;
        private int timeout = 8;
        private Socket? serverSocket;
        private string? contentPath;
        private readonly IRequestHandler _requestHandler;
        private readonly IExceptionHandler _exceptionHandler;

        public Server(IRequestHandler requestHandler, IExceptionHandler exceptionHandler)
        {
            _requestHandler = requestHandler;
            _exceptionHandler = exceptionHandler;
        }

        public bool StartServer(IPAddress ipAddress, int port, int maxNOfCon, string contentPath, Encoding charEncoder)
        {
            if (running) return false; // If it is already running, exit.

            try
            {
                // A tcp/ip socket (ipv4)
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ipAddress, port));
                serverSocket.Listen(maxNOfCon);
                serverSocket.ReceiveTimeout = timeout;
                serverSocket.SendTimeout = timeout;
                running = true;
                this.contentPath = contentPath;
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                return false;
            }

            StartRequestListener(charEncoder);

            return true;
        }
        public void StopServer()
        {
            if (running)
            {
                running = false;
                try
                {
                    serverSocket?.Close();
                }
                catch (Exception ex)
                {
                    _exceptionHandler.HandleException(ex);
                }
                serverSocket = null;
            }
        }

        private void StartRequestListener(Encoding charEncoder)
        {
            // Our thread that will listen connection requests
            // and create new threads to handle them.
            Thread requestListenerT = new Thread(() =>
            {
                while (running)
                {
                    Socket clientSocket;
                    try
                    {
                        clientSocket = serverSocket!.Accept();
                        // Create new thread to handle the request and continue to listen to the socket.
                        Thread requestHandler = new Thread(() =>
                        {
                            clientSocket.ReceiveTimeout = timeout;
                            clientSocket.SendTimeout = timeout;
                            try
                            {
                                _requestHandler.HandleTheRequest(clientSocket, this.contentPath!, charEncoder);
                            }
                            catch (Exception outerEx)
                            {
                                try
                                {
                                    clientSocket.Close();
                                }
                                catch (Exception ex)
                                {
                                    _exceptionHandler.HandleException(ex);
                                }

                                _exceptionHandler.HandleException(outerEx);
                            }
                        });
                        requestHandler.Start();
                    }
                    catch (Exception ex)
                    {
                        _exceptionHandler.HandleException(ex);
                    }
                }
            });
            requestListenerT.Start();
        }
    }
}
