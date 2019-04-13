/********************************************************************************
 * Diagnostics QuickStart Library - General utility to write log messages to 
 * different log types. 
 * 
 * NOTE: Adapted from CSHARP.Diagnostics which was extracted from Clinch.Core
 * 
 * LICENSE: Free to use provided details on fixes and/or extensions emailed to 
 *          chris.williams@readwatchcreate.com
 ********************************************************************************/

using System.Text;

namespace DiagnosticsQuickStart.Business
{
    /// <summary>
    /// Supports storing event log messages in memory
    /// </summary>
    /// <remarks>NEW in v1.0.0.2</remarks>
    public class MemoryEventLog
    {
        /// <summary>
        /// Connection String not applicable for memory event log
        /// </summary>
        public string ConnectionString { get { return string.Empty; } set { return; } }
        /// <summary>
        /// Parameters not applicable for memory event log
        /// </summary>
        public string Parameters { get { return string.Empty; } set { return; } }

        /// <summary>
        /// Verbose used to filter messages written to log
        /// </summary>
        public int VerboseLevel { get; set; }

        /// <summary>
        /// Flush log not applicable to Memory event log
        /// </summary>
        public void FlushEventLog()
        {
        }

        /// <summary>
        /// Returns the current contents of the event log as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _eventLogMessages.ToString();
        }
        private StringBuilder _eventLogMessages = new StringBuilder();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public void LogEvent(int level, string message)
        {
            _eventLogMessages.AppendLine(message);
        }
    }
}
