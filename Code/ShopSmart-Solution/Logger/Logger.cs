using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Log
{
    public static class Logger
    {
        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Log(string message)
        {
            //untill we have a logger, write to output
            Debug.WriteLine(">======================");
            Debug.WriteLine(message);
            Debug.WriteLine("======================<");
        }
    }
}
