/********************************************************************************
 * Diagnostics QuickStart Library - General utility to write log messages to 
 * different log types. 
 * 
 * NOTE: Adapted from CSHARP.Diagnostics which was extracted from Clinch.Core
 * 
 * LICENSE: Free to use provided details on fixes and/or extensions emailed to 
 *          chris.williams@readwatchcreate.com
 ********************************************************************************/

using System;

namespace DiagnosticsQuickStart.Business
{
    /// <summary>
    /// Console Event Log Handler
    /// </summary>
    public class ConsoleEventLog : IEventLog
    {
        /// <summary>
        /// Connection string used to write to log
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Additional parameters used to write to log
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// Levels to log (0 = all, 1 to 10 level of verbosity)
        /// </summary>
        public int VerboseLevel { get { return 0; /* TO DO: Should read from app.config */ } }

        /// <summary>
        /// Writes event message to log
        /// </summary>
        /// <param name="level">1 to 10 increased level of verbosity</param>
        /// <param name="message">message to write</param>
        /// <remarks>V1.0.0.1 Added end of line marker for console error messages if error message does not end in end of line marker.</remarks>
        public void LogEvent(int level, string message)
        {
            if (VerboseLevel == 0 || level <= VerboseLevel) Console.Write(message + (message.EndsWith("\r\n") == false ? "\r\n" : ""));
        }

        /// <summary>
        /// Flushing event log to console does nothing
        /// </summary>
        public void FlushEventLog()
        {
        }
    }
}