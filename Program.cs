using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebServerWithGui.Interfaces;
using WebServerWithGui.Utility;
using WebServerWithGui.WebServer;

namespace WebServerWithGui
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        static void Main()
        {
            IExceptionHandler exceptionHandler = new ExceptionHandler();
            IResponseHandler responseHandler = new ResponseHandler(exceptionHandler);
            IStatusCodeHandler statusCodeHandler = new StatusCodeHandler(responseHandler);
            IRequestHandler requestHandler = new RequestHandler(exceptionHandler, statusCodeHandler);
            IServer serverHandler = new Server(requestHandler, exceptionHandler);
            StringToByteArray stringToBytes = new StringToByteArray(exceptionHandler);
            StringToInt stringToInt = new StringToInt(exceptionHandler);
            Manager manager = new Manager(serverHandler, stringToBytes, stringToInt);

            manager.StartUp();
        }
    }
}