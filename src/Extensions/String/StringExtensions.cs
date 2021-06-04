using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Maestria.Extensions
{
    public static partial class StringExtensions
    {
        private static readonly Regex NonDigitsRegex = new Regex(@"[^\d]+");

        /// <summary>
        /// Compare two texts ignoring char case
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueToCompare"></param>
        /// <param name="autoTrim"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string value, string valueToCompare, bool autoTrim = true)
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

        /// <summary>
        /// Join string values
        /// </summary>
        /// <param name="values"></param>
        /// <param name="separator">Text to separe itens</param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> values, string separator)
        {
            return string.Join(separator, values);
        }

        /// <summary>
        /// Replaces the format item in a specified string with the string representation of a corresponding object in a specified array.
        /// </summary>
        /// <param name="value">A <see cref="~/docs/standard/base-types/composite-formatting.md">composite format string</see>.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of <paramref name="format">format</paramref> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args">args</paramref>.</returns>
        /// <exception cref="T:System.FormatException"><paramref name="format">format</paramref> is invalid.   -or-   The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args">args</paramref> array.</exception>
        [StringFormatMethod("value")]
        public static string Format(this string value, params object[] args)
        {
            if (value.IsNullOrWhiteSpace() || args == null || args.Length == 0)
                return value;
            return string.Format(value, args);
        }

        /// <summary>
        /// Return only numeric chars at text. It's preserved <paramref name="culture"/> decimal separator and negative sign.
        /// </summary>
        /// <param name="value">Value to clear alphanumeric chars</param>
        /// <param name="allowFloatingPoint">Return numbers with dot char</param>
        /// <param name="allowNegativeSign">return numbers with negative sign</param>
        /// <param name="culture">Culture UI</param>
        /// <returns></returns>
        public static string OnlyNumbers(this string value, bool allowFloatingPoint = false, bool allowNegativeSign = false, CultureInfo culture = null)
        {
            if (string.IsNullOrEmpty(value)) return value;
            if (!allowFloatingPoint && !allowNegativeSign) return NonDigitsRegex.Replace(value, "");

            var pattern = @"[^\d";
            if (allowFloatingPoint)
                pattern += (culture ?? CultureInfo.InvariantCulture).NumberFormat.NumberDecimalSeparator;
            if (allowNegativeSign)
                pattern += (culture ?? CultureInfo.InvariantCulture).NumberFormat.NegativeSign;
            pattern += "]+";
            return new Regex(pattern).Replace(value, "");
        }

        public static string RemoveAccents(this string text)
        {
            var result = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (var letter in arrayText)
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    result.Append(letter);
            return result.ToString();
        }

        /// <summary>
        /// Limit <see cref="value"/> with <see cref="length"/> character number safe.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="length">Max size of return value</param>
        /// <returns></returns>
        public static string LimitLen(this string value, int length) => value.SubstringSafe(0, length);

        /// <summary>
        /// Limit <see cref="value"/> with <see cref="length"/> character number safe from right to left.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="length">Max size of return value</param>
        /// <returns></returns>
        public static string LimitLenReverse(this string value, int length) => value?.SubstringSafe(AggregateExtensions.Max(value.Length - length, 0), length);

        /// <summary>
        /// Save string content on disk
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fileName"></param>
        /// <param name="append"></param>
        public static void SaveAs(this string value, string fileName, bool append = false)
        {
            using var tw = new StreamWriter(fileName, append);
            tw.Write(value ?? string.Empty);
        }

        /// <summary>
        /// Save string content on disk
        /// </summary>
        /// <param name="value"></param>
        /// <param name="file"></param>
        /// <param name="append"></param>
        public static void SaveAs(this string value, FileInfo file, bool append = false)
        {
            using var tw = new StreamWriter(file.FullName, append);
            tw.Write(value ?? string.Empty);
        }

        /// <summary>
        /// Escape <paramref name="value"/> as XML replacing special chars by escape codes.
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string EscapeXml(this string value) => value
            .Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;")
            .Replace("'", "&apos;");
    }
}