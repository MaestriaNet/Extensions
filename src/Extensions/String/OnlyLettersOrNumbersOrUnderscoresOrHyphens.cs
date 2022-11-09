using System.Text.RegularExpressions;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    private static readonly Regex OnlyLettersOrNumbersOrUnderscoresOrHyphensRegex = new Regex(@"[^a-zA-Z0-9_-]+");

    /// <summary>
    /// Return only numerics (0-9), chars (a-Z), underscores (_) or hyphens (-) at text.
    /// </summary>
    /// <param name="value">Value to clear</param>
    /// <returns></returns>
    public static string? OnlyLettersOrNumbersOrUnderscoresOrHyphens(this string? value) =>
        value != null
            ? OnlyLettersOrNumbersOrUnderscoresOrHyphensRegex.Replace(value, "")
            : null;
}