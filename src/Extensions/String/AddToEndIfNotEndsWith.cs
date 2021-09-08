using System.Globalization;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Add value to end of text if the text not end with value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and concat to end of text when text not end with this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string AddToEndIfNotEndsWith(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null) return equality;
            if (equality == null) return value;
            return value.EndsWith(equality, ignoreCase, CultureInfo.InvariantCulture)
                ? value
                : value + equality;
        }

        /// <summary>
        /// Add value to end of text if the text not end with value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and concat to end of text when text not end with this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string AddToEndIfNotEndsWith(this string value, char equality, bool ignoreCase = true) => value.AddToEndIfNotEndsWith(equality.ToString(), ignoreCase);
    }
}