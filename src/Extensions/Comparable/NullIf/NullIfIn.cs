using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static T? NullIfIn<T>(this T value, params T[] values) where T : struct, IComparable =>
            value.In(values) ? (T? )null : value;
    }
}