using System.Globalization;
using System.Text.RegularExpressions;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        private static readonly Regex NonDigitsRegex = new Regex(@"[^\d]+");

        /// <summary>
        /// Return only numeric chars at text. It's preserved <paramref name="culture"/> decimal separator and negative sign.
        /// </summary>
        /// <param name="value">Value to clear alphanumeric chars</param>
        /// <param name="allowFloatingPoint">Return numbers with dot char</param>
        /// <param name="allowNegativeSign">return numbers with negative sign</param>
        /// <param name="culture">Culture UI</param>
        /// <returns></returns>
        public static string? OnlyNumbers(this string? value, bool allowFloatingPoint = false, bool allowNegativeSign = false, CultureInfo? culture = null)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            if (!allowFloatingPoint && !allowNegativeSign) return NonDigitsRegex.Replace(value, "");

            var pattern = @"[^\d";
            if (allowFloatingPoint)
                pattern += (culture ?? CultureInfo.InvariantCulture).NumberFormat.NumberDecimalSeparator;
            if (allowNegativeSign)
                pattern += (culture ?? CultureInfo.InvariantCulture).NumberFormat.NegativeSign;
            pattern += "]+";
            return new Regex(pattern).Replace(value, "");
        }
    }
}