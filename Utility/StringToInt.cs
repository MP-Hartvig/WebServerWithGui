using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServerWithGui.Interfaces;

namespace WebServerWithGui.Utility
{
    public class StringToInt
    {
		private readonly IExceptionHandler _exceptionHandler;

        public StringToInt(IExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        public int GetIntFromString(string input)
        {
			try
			{
                return Convert.ToInt32(input);
			}
			catch (Exception ex)
			{
                _exceptionHandler.HandleException(ex);
				throw ex;
			}
        }
    }
}
