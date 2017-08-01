using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.AddressBook.Logging
{
    public class Logger : ILogger
    {
        private static readonly object lockobj = new object();
        private static readonly bool logsEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableLogs"]);
        private static readonly string logdir = ConfigurationManager.AppSettings["LogDir"];
        private static readonly string eventSrc = ConfigurationManager.AppSettings["EventSrc"];
        private static readonly string eventLog = ConfigurationManager.AppSettings["LogName"];

        public void LogError(Exception ex)
        {
            WriteToLogFile(ex.Message);
        }

        public void WriteErrorLogToFile(string message)
        {
            WriteToLogFile(message);
        }

        public void WriteToEventViewer(string message)
        {
            try
            {
                if (!EventLog.SourceExists(eventSrc))
                {
                    EventLog.CreateEventSource(eventSrc, eventLog);
                    return;
                }
                EventLog.WriteEntry(eventSrc, message, EventLogEntryType.Error);
            }
            catch (Exception)
            {

            }
        }

        private void WriteToLogFile(string message)
        {
            if (!logsEnabled) return;

            var filePath = Path.Combine(logdir, string.Format(eventLog + "Log_{0}.log", DateTime.Now.ToString("dd-MM-yyyy")));
            try
            {
                lock(lockobj)
                {
                    using (var writer = new StreamWriter(filePath, true) { AutoFlush = true })
                    {
                        writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy H:mm:ss") + " :: " + message);
                        writer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteToEventViewer(message);
            }
        }
    }
}
