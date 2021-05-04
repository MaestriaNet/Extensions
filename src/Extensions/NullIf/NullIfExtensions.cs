using System;
using System.Collections.Generic;

namespace Maestria.Extensions
{
    public static partial class NullIfExtensions
    {
        public static T? NullIf<T>(this T value, T equalityValue) where T : struct =>
            EqualityComparer<T>.Default.Equals(value, equalityValue) ? (T?) null : value;

        public static T? NullIf<T>(this T? value, T? equalityValue) where T : struct =>
            EqualityComparer<T?>.Default.Equals(value, equalityValue) ? (T?) null : value;

        public static T NullIf<T>(this object value, T equalityValue) where T : class =>
            value != null && equalityValue != null && value.Equals(equalityValue) ? null : (T) value;

        public static T? NullIfIn<T>(this T value, params T[] values) where T : struct, IComparable =>
            value.In(values) ? (T? )null : value;

        public static T? NullIfBetween<T>(this T value, T starting, T ending) where T : struct, IComparable =>
            value.Between(starting, ending) ? (T? )null : value;
    }
}