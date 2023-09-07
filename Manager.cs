using Microsoft.Extensions.Hosting;
using System.Net;
using System.Text;
using WebServerWithGui.Interfaces;
using WebServerWithGui.Utility;
using Microsoft.Extensions.DependencyInjection;
using WebServerWithGui.WebServer;

namespace WebServerWithGui
{
    public class Manager
    {
        private readonly IServer _serverHandler;
        private readonly StringToByteArray _stringToBytes;
        private readonly StringToInt _stringToInt;
        Encoding charEncoder = Encoding.UTF8;
        int maxNOfCon = 10;

        [STAThread]
        public void StartUp()
        {
            using IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<IExceptionHandler, ExceptionHandler>();
                services.AddSingleton<IRequestHandler, RequestHandler>();
                services.AddSingleton<IResponseHandler, ResponseHandler>();
                services.AddSingleton<IStatusCodeHandler, StatusCodeHandler>();
                services.AddSingleton<StringToByteArray>();
                services.AddSingleton<StringToInt>();
                services.AddSingleton<IServer, Server>();
                services.AddSingleton<Manager>();
            }).Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(this));
        }

        public Manager(IServer serverHandler, StringToByteArray stringToBytes, StringToInt stringToInt)
        {
            _stringToInt = stringToInt;
            _serverHandler = serverHandler;
            _stringToBytes = stringToBytes;
        }

        public void StartServer(string ipAddress, string portNumber, string contentPath)
        {
            //IPAddress ip = new IPAddress(_stringToBytes.GetBytesFromString(ipAddress, charEncoder));

            int port = _stringToInt.GetIntFromString(portNumber);

            _serverHandler.StartServer(IPAddress.Loopback, port, maxNOfCon, contentPath, charEncoder);
        }

        public void StopServer()
        {
            _serverHandler.StopServer();
        }
    }
}
