/********************************************************************************
 * Diagnostics QuickStart Library - General utility to write log messages to 
 * different log types. 
 * 
 * NOTE: Adapted from CSHARP.Diagnostics which was extracted from Clinch.Core
 * 
 * LICENSE: Free to use provided details on fixes and/or extensions emailed to 
 *          chris.williams@readwatchcreate.com
 ********************************************************************************/

namespace DiagnosticsQuickStart.Provider.Speaking
{
    using DiagnosticsQuickStart.Business;
    using System;
    using TextToSpeechQuickStart.Business;
    using TraitsQuickStart.Data;

    /// <summary>
    /// This is the generic version that uses basic speech. Additional Voices will be provided in future versions.
    /// </summary>
    public class SpeakingConsoleEventLog : IEventLog
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
        /// 
        /// </summary>
        public ITraits Traits { get; set; }

        /// <summary>
        /// Writes event message to log
        /// </summary>
        /// <param name="level">1 to 10 increased level of verbosity</param>
        /// <param name="message">message to write</param>
        /// <remarks>V1.0.0.1 Added end of line marker for console error messages if error message does not end in end of line marker.</remarks>
        public void LogEvent(int level, string message)
        {
            var voiceRssTextToSpeechProvider = new VoiceRssTextToSpeechProvider
            {
                Traits = Traits
            };

            // For now we rely on default language from the file but ideally this could switch based on whom is interacting
            if (VerboseLevel == 0 || level <= VerboseLevel)
            {
                // Don't say level 2 log messages as it is only information.
                if (level < 2)
                {
                    // Truncate any log messages to 128
                    voiceRssTextToSpeechProvider.PlayAudioForText(message.Length > 128 ? message.Substring(0, 128) : message, string.Empty);
                }
            }

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
