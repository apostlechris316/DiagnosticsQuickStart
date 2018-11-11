/********************************************************************************
 * Diagnostics QuickStart Library - General utility to write log messages to 
 * different log types. 
 * 
 * NOTE: Adapted from CSHARP.Diagnostics which was extracted from Clinch.Core
 * 
 * LICENSE: Free to use provided details on fixes and/or extensions emailed to 
 *          chris.williams@readwatchcreate.com
 ********************************************************************************/

using System.IO;

namespace DiagnosticsQuickStart.Business
{
    /// <summary>
    /// File System Event Log Handler
    /// </summary>
    public class FileSystemEventLog : IEventLog
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
        public void LogEvent(int level, string message)
        {
            if (VerboseLevel == 0 || level <= VerboseLevel) File.AppendAllText(ConnectionString, message);
        }

        /// <summary>
        /// Flushing event log for file does nothing
        /// </summary>
        public void FlushEventLog()
        {
        }
    }
}
