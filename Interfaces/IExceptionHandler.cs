using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerWithGui.Interfaces
{
    public interface IExceptionHandler
    {
        public void HandleException(Exception ex);
    }
}
