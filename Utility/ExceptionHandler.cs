using System.Diagnostics;
using WebServerWithGui.Interfaces;

namespace WebServerWithGui.Utility
{
    public class ExceptionHandler : IExceptionHandler
    {
        public void HandleException(Exception ex)
        {
            string exMessage = "";

            if (ex.InnerException == null)
            {
                exMessage = ex.Message;
            }
            else
            {
                exMessage = ex.InnerException.Message;
            }

            Debug.WriteLine("Exception caught with the following message: " + exMessage);
        }
    }
}
