using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace DVLD_DataAccess
{
   

    public static class clsEventLogger
    {
        private static string source = "DVLDApp";
        private static string logName = "Application";

        public static void LogError(string message)
        {
            // Create source if it doesn't exist
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, logName);
            }

            // Write error
            EventLog.WriteEntry(source, message, EventLogEntryType.Error);
        }
    }
}
