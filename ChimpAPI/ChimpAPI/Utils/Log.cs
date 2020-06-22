using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimpAPI.Utils
{
    public class Log : EventArgs
    {
        public Log(string msg, Logger.Severity severity, StackTrace stack = null)
        {
            Message = msg;
            Severity = severity;
            Stack = stack;
        }
        public string Message { get; private set; }
        public Logger.Severity Severity { get; private set; }

        public StackTrace Stack { get; private set; }
    }
}
