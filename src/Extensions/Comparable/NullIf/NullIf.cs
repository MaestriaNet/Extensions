using System.Collections.Generic;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static T? NullIf<T>(this T value, T equalityValue) where T : struct =>
            EqualityComparer<T>.Default.Equals(value, equalityValue) ? (T?)null : value;

        public static T? NullIf<T>(this T? value, T? equalityValue) where T : struct =>
            EqualityComparer<T?>.Default.Equals(value, equalityValue) ? (T?)null : value;

        public static T? NullIf<T>(this object? value, T? equalityValue) where T : class =>
            value != null && equalityValue != null && value.Equals(equalityValue) ? null : (T?) value;
    }
}