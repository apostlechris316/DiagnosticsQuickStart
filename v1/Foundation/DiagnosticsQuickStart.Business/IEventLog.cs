/********************************************************************************
 * Diagnostics QuickStart Library - General utility to write log messages to 
 * different log types. 
 * 
 * NOTE: Adapted from CSHARP.Diagnostics which was extracted from Clinch.Core
 * 
 * LICENSE: Free to use provided details on fixes and/or extensions emailed to 
 *          chris.williams@readwatchcreate.com
 ********************************************************************************/

namespace DiagnosticsQuickStart.Business
{
    /// <summary>
    /// Interface that supports writing log messages
    /// </summary>
    public interface IEventLog
    {
        /// <summary>
        /// Connection string used to write to log
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Additional parameters used to write to log
        /// </summary>
        string Parameters { get; set; }

        /// <summary>
        /// Gets level of verbosity to log (0 to 10)
        /// </summary>
        int VerboseLevel { get; }

        /// <summary>
        /// Writes event message to log
        /// </summary>
        /// <param name="level">0 = all, 1 to 10 increased level of verbosity</param>
        /// <param name="message">message to write</param>
        void LogEvent(int level, string message);

        /// <summary>
        /// Sometimes for optimization log is flushed at intervals
        /// </summary>
        void FlushEventLog();
    }
}
