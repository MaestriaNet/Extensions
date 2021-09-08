using System.Globalization;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Remove prefix (left part) if text beginning with equality value. The part to remove is exactly checked value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and remove from text, if text beginning equals this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string TrimStart(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null || equality == null)
                return value;
            while (value.StartsWith(equality, ignoreCase, CultureInfo.InvariantCulture))
                value = value.Remove(0, equality.Length);
            return value;
        }

        /// <summary>
        /// Remove prefix (left part) if text beginning with equality value. The part to remove is exactly checked value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and remove from text, if text beginning equals this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string TrimStart(this string value, char equality, bool ignoreCase = true) => value.TrimStart(equality.ToString(), ignoreCase);
    }
}