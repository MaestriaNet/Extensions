using System;
using System.Text;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Obtain message with inner exception cascade message.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="additionalInfo">Text to write into first line when not is empty.</param>
        /// <param name="includeClassType">Output with exception class full name.</param>
        /// <param name="includeStackTrace"></param>
        /// <returns></returns>
        [Obsolete("Create similiar method in your project")]
        public static string GetAllMessages(this Exception value, string? additionalInfo = null,
            bool includeClassType = true, bool includeStackTrace = true)
        {
            if (value == null)
                return string.Empty;

            var msg = new StringBuilder();
            var stackTrace = new StringBuilder();
            if (additionalInfo.HasValue())
                msg.AppendLine(additionalInfo);

            msg.AppendLine(value.Message);
            if (includeClassType)
                msg.AppendLine("Type: " + value.GetType().FullName);

            if (value.StackTrace.HasValue())
                stackTrace.AppendLine(value.StackTrace);

            if (value.InnerException != null)
            {
                var innerCount = 0;
                for (var ex = value.InnerException; ex != null; ex = ex.InnerException)
                    innerCount++;

                int innerLevel = 1;
                for (var ex = value.InnerException; ex != null; ex = ex.InnerException)
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
    }
}