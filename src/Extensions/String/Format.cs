using JetBrains.Annotations;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {

        /// <summary>
        /// Replaces the format item in a specified string with the string representation of a corresponding object in a specified array.
        /// </summary>
        /// <param name="value">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of <paramref name="value">format</paramref> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args">args</paramref>.</returns>
        /// <exception cref="T:System.FormatException"><paramref name="value">format</paramref> is invalid.   -or-   The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args">args</paramref> array.</exception>
        [StringFormatMethod("value")]
        public static string Format(this string value, params object[] args)
        {
            if (value.IsNullOrWhiteSpace() || args == null || args.Length == 0)
                return value;
            return string.Format(value, args);
        }
    }
}