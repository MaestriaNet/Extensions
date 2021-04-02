using System;
using System.Text;

namespace Maestria.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Obtain message with inner exception cascade message.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="additionalInfo">Text to write into first line when not is empty.</param>
        /// <param name="includeClassType">Output with exception class full name.</param>
        /// <param name="includeStackTrace"></param>
        /// <returns></returns>
        public static string GetAllMessages(this Exception exception, string additionalInfo = null,
            bool includeClassType = true, bool includeStackTrace = true)
        {
            if (exception == null)
                return string.Empty;

            var msg = new StringBuilder();
            var stackTrace = new StringBuilder();
            if (additionalInfo.HasValue())
                msg.AppendLine(additionalInfo);

            msg.AppendLine(exception.Message);
            if (includeClassType)
                msg.AppendLine("Type: " + exception.GetType().FullName);

            if (exception.StackTrace.HasValue())
                stackTrace.AppendLine(exception.StackTrace);

            if (exception.InnerException != null)
            {
                var innerCount = 0;
                for (var ex = exception.InnerException; ex != null; ex = ex.InnerException)
                    innerCount++;

                int innerLevel = 1;
                for (var ex = exception.InnerException; ex != null; ex = ex.InnerException)
                {
                    if (innerCount > 1)
                        msg.Append($@"Inner {innerCount - innerLevel}");
                    else
                        msg.Append(@"Inner");

                    if (includeClassType)
                        msg.Append($@": {ex.GetType().FullName}");

                    msg.Append(@" -> ");
                    msg.AppendLine(ex.Message);
                    if (ex.StackTrace.HasValue())
                        stackTrace.AppendLine(ex.StackTrace);
                    innerLevel++;
                }
            }

            if (includeStackTrace && stackTrace.Length > 0)
                msg.Append(@"StackTrace: " + stackTrace.ToString().TrimEnd());

            return msg.ToString();
        }

        [Obsolete("Use 'GetAllMessages'")]
        public static string ToLogString(this Exception exception, string additionalInfo = null,
            bool includeClassType = true, bool includeStackTrace = true) => GetAllMessages(exception, additionalInfo, includeClassType, includeStackTrace);

        /// <summary>
        /// Gets the most inner (deepest) exception of a given Exception object
        /// </summary>
        /// <param name="ex">Source Exception</param>
        /// <returns></returns>
        public static Exception GetMostInner(this Exception ex) =>
            ex.InnerException == null ? ex : ex.InnerException.GetMostInner();

        // public static string PrettifyStackTrace(this Exception ex) => PrettifyStackTrace(ex.StackTrace);

        // public static string PrettifyStackTrace(string stackTrace)
        // {
        //     return stackTrace;
        // }
    }
}