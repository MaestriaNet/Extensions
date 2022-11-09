using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Return null if <paramref name="value"/> is equals to <paramref name="equalityValue"/>
    /// </summary>
    /// <param name="value">Current text</param>
    /// <param name="equalityValue">Text to compare with <paramref name="value"/> and return null if equals</param>
    /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
    /// <returns>null if <paramref name="value"/> is equals to <paramref name="equalityValue"/></returns>
    public static string? NullIf(this string? value, string? equalityValue, bool ignoreCase = false)
    {
        if (value == null || equalityValue == null)
            return value;

        return value.Equals(equalityValue,
            ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture)
            ? null
            : value;
    }
}