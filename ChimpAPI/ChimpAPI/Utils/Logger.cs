using ChimpAPI.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimpAPI
{
    public class Logger
    {
        public static event EventHandler NewLogEvent;

        public static List<Log> Logs = new List<Log>();

        /// <summary>
        /// Creates a new log
        /// </summary>
        /// <param name="msg">The Description for the log</param>
        /// <param name="severity">The level of severity</param>
        /// <param name="stack">The StackFrame for which a event occured.</param>
        public static void Log(string msg, Severity severity, StackTrace stack = null)
        {
            var log = new Log(msg, severity, stack);
            Logs.Add(log);
            
            if (NewLogEvent != null)
            {
                NewLogEvent("Logger", log);
            }
        }

        public enum Severity
        {
            Info,
            Debug,
            Error
        }
    }
}
