namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Add value to ends of text if the text is not null or white space.
    /// </summary>
    /// <param name="value">Text to manipulate</param>
    /// <param name="suffix">To concat at the ending of text</param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string AddToEndIfHasValue(this string? value, string suffix) =>
        value.HasValue() ? value + suffix : value ?? string.Empty;

    /// <summary>
    /// Add value to ends of text if the text is not null or white space.
    /// </summary>
    /// <param name="value">Text to manipulate</param>
    /// <param name="suffix">To concat at the ending of text</param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string AddToEndIfHasValue(this string? value, char suffix) => value.AddToEndIfHasValue(suffix.ToString());
}