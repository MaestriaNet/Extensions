using System;
using System.Linq;

namespace Maestria.Extensions
{
    /// <summary>
    /// Syntax extensions to humanize reading source code
    /// </summary>
    public static class SyntaxExtensions
    {
        /// <summary>
        /// Check if value is contained within expected values
        /// </summary>
        /// <param name="value"></param>
        /// <param name="checkValues"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T value, params T[] checkValues) =>
            value != null && checkValues != null && checkValues.Contains(value);

        /// <summary>
        /// Check if value is within expected range
        /// </summary>
        /// <param name="value"></param>
        /// <param name="starting"></param>
        /// <param name="ending"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Between<T>(this T value, T starting, T ending) where T : IComparable =>
            value != null && starting != null && ending != null &&
            value.CompareTo(starting) >= 0 && value.CompareTo(ending) <= 0;
    }
}