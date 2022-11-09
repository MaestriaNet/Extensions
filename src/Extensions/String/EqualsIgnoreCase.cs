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
        value = value ?? string.Empty;
        valueToCompare = valueToCompare ?? string.Empty;

        if (autoTrim)
        {
            value = value.Trim();
            valueToCompare = valueToCompare.Trim();
        }

        return value.Equals(valueToCompare, StringComparison.InvariantCultureIgnoreCase);
    }
}