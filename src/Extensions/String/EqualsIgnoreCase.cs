using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Compare two texts ignoring char case
    /// </summary>
    /// <param name="value"></param>
    /// <param name="valueToCompare"></param>
    /// <param name="autoTrim"></param>
    /// <returns></returns>
    public static bool EqualsIgnoreCase(this string? value, string? valueToCompare, bool autoTrim = true)
    {
#if NETSTANDARD2_0
        value ??= string.Empty;
        valueToCompare ??= string.Empty;

        if (autoTrim)
        {
            if (value.Length > 0 && (char.IsWhiteSpace(value[0]) || char.IsWhiteSpace(value[value.Length - 1])))
                value = value.Trim();
            if (valueToCompare.Length > 0 && (char.IsWhiteSpace(valueToCompare[0]) || char.IsWhiteSpace(valueToCompare[valueToCompare.Length - 1])))
                valueToCompare = valueToCompare.Trim();
        }

        return value.Equals(valueToCompare, StringComparison.OrdinalIgnoreCase);
#else
        var span = value.AsSpan();
        var spanToCompare = valueToCompare.AsSpan();

        if (autoTrim)
        {
            span = span.Trim();
            spanToCompare = spanToCompare.Trim();
        }

        return span.Equals(spanToCompare, StringComparison.OrdinalIgnoreCase);
#endif
    }
}