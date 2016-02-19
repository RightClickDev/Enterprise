//------------------------------------------------------------------------------------------------- 
// <copyright file="ErrorHelper.cs" company="Right Click Development">
//  Copyright (c) Right Click Development. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace RightClick.Enterprise.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Error Helper utility class
    /// </summary>
    public static class ErrorHelper
    {
        /// <summary>
        /// Logs the success audit.
        /// </summary>
        /// <param name="informationMessage">The information message.</param>
        public static void LogSuccessAudit(string informationMessage)
        {
            using (EventLog eventLog = new EventLog())
            {
                eventLog.Source = ConfigurationManager.AppSettings["EventViewerSource"];
                eventLog.Log = ConfigurationManager.AppSettings["EventViewerName"];

                var error = new StringBuilder();
                error.Append(informationMessage);

                if (!EventLog.SourceExists(eventLog.Source))
                {
                    EventLog.CreateEventSource(eventLog.Source, eventLog.Log);
                }

                eventLog.WriteEntry(error.ToString(), EventLogEntryType.SuccessAudit);
                eventLog.Close();
            }
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void LogErrorMessage(Exception exception)
        {
            if (exception.Message != "Thread was being aborted.")
            {
                using (EventLog eventLog = new EventLog())
                {
                    eventLog.Source = ConfigurationManager.AppSettings["EventViewerSource"];
                    eventLog.Log = ConfigurationManager.AppSettings["EventViewerName"];

                    var error = new StringBuilder();
                    error.Append(GetExceptionLogText(exception));

                    if (!EventLog.SourceExists(eventLog.Source))
                    {
                        EventLog.CreateEventSource(eventLog.Source, eventLog.Log);
                    }

                    eventLog.WriteEntry(error.ToString(), EventLogEntryType.Error);
                    eventLog.Close();
                }
            }
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message.</param>
        public static void LogErrorMessage(Exception exception, string message)
        {
            if (exception.Message != "Thread was being aborted.")
            {
                using (EventLog eventLog = new EventLog())
                {
                    eventLog.Source = ConfigurationManager.AppSettings["EventViewerSource"];
                    eventLog.Log = ConfigurationManager.AppSettings["EventViewerName"];

                    var error = new StringBuilder();
                    error.Append(GetExceptionLogText(exception));
                    error.Append(" message: ");
                    error.Append(message);

                    if (!EventLog.SourceExists(eventLog.Source))
                    {
                        EventLog.CreateEventSource(eventLog.Source, eventLog.Log);
                    }

                    eventLog.WriteEntry(error.ToString(), EventLogEntryType.Error);
                    eventLog.Close();
                }
            }
        }

        /// <summary>
        /// Returns the contents of an exception for display in a log message
        /// </summary>
        /// <param name="ex">The exception to log</param>
        /// <returns>A string built up from the exception contents</returns>
        public static string GetExceptionLogText(Exception ex)
        {
            int errorDepth = 0;
            StringBuilder error = new StringBuilder();
            while (ex != null && errorDepth <= 10)
            {
                error.AppendFormat(ex.ToString());
                ex = ex.InnerException;
                if (ex != null && ++errorDepth <= 10)
                {
                    error.AppendFormat("+++Inner Excepton {0}+++\n", errorDepth);
                }
            }

            return error.ToString();
        }
    }
}
