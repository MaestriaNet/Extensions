using System.Globalization;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Add value to start of text if the text not beginning with value.
    /// </summary>
    /// <param name="value">Text to manipulate</param>
    /// <param name="equality">To check and concat to start of text when text not beginning with this value</param>
    /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string AddToBeginningIfNotStartsWith(this string? value, string equality, bool ignoreCase = true)
    {
        if (value == null)
            return equality ?? string.Empty;
        if (equality == null)
            return value ?? string.Empty;
        return value.StartsWith(equality, ignoreCase, CultureInfo.InvariantCulture)
            ? value
            : equality + value;
    }

    /// <summary>
    /// Add value to start of text if the text not beginning with value.
    /// </summary>
    /// <param name="value">Text to manipulate</param>
    /// <param name="equality">To check and concat to start of text when text not beginning with this value</param>
    /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string AddToBeginningIfNotStartsWith(this string? value, char equality, bool ignoreCase = true) => value.AddToBeginningIfNotStartsWith(equality.ToString(), ignoreCase);
}