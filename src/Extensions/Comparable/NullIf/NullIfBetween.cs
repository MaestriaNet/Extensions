using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static T? NullIfBetween<T>(this T value, T starting, T ending) where T : struct, IComparable =>
        value.Between(starting, ending) ? (T?)null : value;
}