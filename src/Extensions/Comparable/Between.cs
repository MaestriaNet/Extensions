using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
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