using System.Globalization;
using System.Text;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="text"></param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string RemoveAccents(this string? text)
    {
        if (text == null)
            return string.Empty;

        var result = new StringBuilder();
        var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
        foreach (var letter in arrayText)
            if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                result.Append(letter);
        return result.ToString();
    }
}