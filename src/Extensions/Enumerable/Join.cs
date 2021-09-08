using System.Collections.Generic;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Join string values
        /// </summary>
        /// <param name="values"></param>
        /// <param name="separator">Text to separe itens</param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> values, string separator) => string.Join(separator, values);

        /// <summary>
        /// Join string values
        /// </summary>
        /// <param name="values"></param>
        /// <param name="separator">Text to separe itens</param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> values, char separator) => string.Join(separator.ToString(), values);
    }
}