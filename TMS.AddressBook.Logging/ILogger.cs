using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.AddressBook.Logging
{
    public interface ILogger
    {
        void LogError(Exception ex);
        void WriteErrorLogToFile(string message);
        void WriteToEventViewer(string message);
    }
}
