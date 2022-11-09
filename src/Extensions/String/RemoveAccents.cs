using System.Globalization;
using System.Text;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static string? RemoveAccents(this string? text)
        {
            if (text == null)
                return null;

            var result = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (var letter in arrayText)
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    result.Append(letter);
            return result.ToString();
        }
    }
}