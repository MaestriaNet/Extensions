using System.Text.RegularExpressions;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    private static readonly Regex OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpacesRegex = new Regex(@"[^a-zA-Z0-9\s_-]+");

    /// <summary>
    /// Return only numerics (0-9), chars (a-Z), underscores (_) or hyphens (-) at text.
    /// </summary>
    /// <param name="value">Value to clear</param>
    /// <returns></returns>
    public static string OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpaces(this string? value) =>
     value != null
        ? OnlyLettersOrNumbersOrUnderscoresOrHyphensOrSpacesRegex.Replace(value, "")
        : string.Empty;
}