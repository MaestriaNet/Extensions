using System;
using System.Linq;

namespace Maestria.Extensions
{
    public static class SyntaxExtensions
    {
        public static bool In<T>(this T value, params T[] checkValues) =>
            value != null && checkValues != null && checkValues.Contains(value);

        public static bool Between<T>(this T value, T starting, T ending) where T : IComparable =>
            value != null && starting != null && ending != null &&
            value.CompareTo(starting) >= 0 && value.CompareTo(ending) <= 0;
    }
}