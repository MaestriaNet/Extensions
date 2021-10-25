using System.Globalization;
using System.Text.RegularExpressions;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        private static readonly Regex Regex = new Regex(@"[^a-zA-Z0-9_]+");

        /// <summary>
        /// Return only numerics (0-9), chars (a-Z) or underscores (_) at text.
        /// </summary>
        /// <param name="value">Value to clear</param>
        /// <returns></returns>
       public static string OnlyLettersOrNumbersOrUnderscoresOrHyphens(this string value) => value != null ? Regex.Replace(value, "") : null;
    }
}