namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Add value to beginning of text if the text is not null or white space.
    /// </summary>
    /// <param name="value">Text to manipulate</param>
    /// <param name="prefix">To concat at the beginning of text</param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string AddToBeginningIfHasValue(this string? value, string prefix) =>
        value.HasValue() ? prefix + value : value ?? string.Empty;

    /// <summary>
    /// Add value to beginning of text if the text is not null or white space.
    /// </summary>
    /// <param name="value">Text to manipulate</param>
    /// <param name="prefix">To concat at the beginning of text</param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string AddToBeginningIfHasValue(this string? value, char prefix) => value.AddToBeginningIfHasValue(prefix.ToString());
}