using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServerWithGui.Interfaces;

namespace WebServerWithGui.Utility
{
    public class StringToByteArray
    {
        private readonly IExceptionHandler _exceptionHandler;

        public StringToByteArray(IExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }
        public byte[] GetBytesFromString(string input, Encoding charEncoder)
        {
            try
            {
                return charEncoder.GetBytes(input);
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                throw ex;
            }
        }
    }
}
