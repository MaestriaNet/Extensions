using System;
using System.Linq;
using JetBrains.Annotations;

namespace Maestria.Extensions
{
    public static class SyntaxExtensions
    {
        public static bool In<T>(this T value, params T[] checkValues) =>
            value != null && checkValues != null && checkValues.Contains(value);

        public static bool Between<T>(this T value, T starting, T ending) where T : IComparable =>
            value != null && starting != null && ending != null &&
            value.CompareTo(starting) >= 0 && value.CompareTo(ending) <= 0;

        public static T? NullIf<T>(this T value, T equalityValue) where T : struct, IComparable =>
            value.CompareTo(equalityValue) == 0 ? (T? )null : value;

        public static T? NullIf2<T>(this object value, T equalityValue) where T : struct, IComparable =>
            equalityValue.CompareTo(value) == 0 ? (T?)null : (T) value;

        public static T? NullIfIn<T>(this T value, params T[] values) where T : struct, IComparable =>
            value.In(values) ? (T? )null : value;

        public static T? NullIfBetween<T>(this T value, T starting, T ending) where T : struct, IComparable =>
            value.Between(starting, ending) ? (T? )null : value;
    }
}