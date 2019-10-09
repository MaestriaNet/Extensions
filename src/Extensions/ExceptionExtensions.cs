using System;

namespace Maestria.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Obtain message with inner exception cascade message. Inner messages are broken into new lines.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="includeClassType"></param>
        /// <returns></returns>
        public static string GetMessageWithInner(this Exception exception, bool includeClassType = false)
        {
            var msg = string.Empty;

            int index = 0;
            while (exception != null)
            {
                var currentExceptionMessage = (includeClassType ? $"[{exception.GetType().FullName}]" : string.Empty) +
                                              exception.Message;
                msg += (index > 0 ? $"\nInner {index}: " : "")  + currentExceptionMessage;
                exception = exception.InnerException;
                index++;
            }

            return msg;
        }
    }
}
