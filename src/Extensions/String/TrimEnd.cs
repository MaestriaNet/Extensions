using System.Globalization;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Remove suffix (right part) if text ends with equality value. The part to remove is exactly checked value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and remove from text, if text end equals this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string TrimEnd(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null || equality == null)
                return value;
            while (value.EndsWith(equality, ignoreCase, CultureInfo.InvariantCulture))
                value = value.Remove(value.Length - equality.Length, equality.Length);
            return value;
        }

        /// <summary>
        /// Remove suffix (right part) if text ends with equality value. The part to remove is exactly checked value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and remove from text, if text end equals this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string TrimEnd(this string value, char equality, bool ignoreCase = true) => value.TrimEnd(equality.ToString(), ignoreCase);
    }
}