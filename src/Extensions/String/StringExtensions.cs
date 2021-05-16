using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Maestria.Extensions
{
    public static partial class StringExtensions
    {
        private static readonly Regex NonDigitsRegex = new Regex(@"[^\d]+");

        /// <summary>
        /// Add value to start of text if the text not beginning with value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and concat to start of text when text not beginning with this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string AddToBeginningIfNotStartsWith(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null)
                return equality;
            if (equality == null)
                return value;
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
        /// <returns></returns>
        public static string AddToBeginningIfNotStartsWith(this string value, char equality, bool ignoreCase = true) => value.AddToBeginningIfNotStartsWith(equality.ToString(), ignoreCase);

        /// <summary>
        /// Add value to end of text if the text not end with value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and concat to end of text when text not end with this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string AddToEndIfNotEndsWith(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null) return equality;
            if (equality == null) return value;
            return value.EndsWith(equality, ignoreCase, CultureInfo.InvariantCulture)
                ? value
                : value + equality;
        }

        /// <summary>
        /// Add value to end of text if the text not end with value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and concat to end of text when text not end with this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string AddToEndIfNotEndsWith(this string value, char equality, bool ignoreCase = true) => value.AddToEndIfNotEndsWith(equality.ToString(), ignoreCase);

        /// <summary>
        /// Add value to beginning of text if the text is not null or white space.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="prefix">To concat at the beginning of text</param>
        /// <returns></returns>
        public static string AddToBeginningIfHasValue(this string value, string prefix) =>
            value.HasValue() ? prefix + value : value;

        /// <summary>
        /// Add value to beginning of text if the text is not null or white space.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="prefix">To concat at the beginning of text</param>
        /// <returns></returns>
        public static string AddToBeginningIfHasValue(this string value, char prefix) => value.AddToBeginningIfHasValue(prefix.ToString());

        /// <summary>
        /// Add value to ends of text if the text is not null or white space.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="suffix">To concat at the ending of text</param>
        /// <returns></returns>
        public static string AddToEndIfHasValue(this string value, string suffix) =>
            value.HasValue() ? value + suffix : value;

        /// <summary>
        /// Add value to ends of text if the text is not null or white space.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="suffix">To concat at the ending of text</param>
        /// <returns></returns>
        public static string AddToEndIfHasValue(this string value, char suffix) => value.AddToEndIfHasValue(suffix.ToString());

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
        /// Return empty if <paramref name="value"/> is equals to <paramref name="equalityValue"/>
        /// </summary>
        /// <param name="value">Current text</param>
        /// <param name="equalityValue">Text to compare with <paramref name="value"/> and return empty if equals</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns>Empty string if <paramref name="value"/> is equals to <paramref name="equalityValue"/></returns>
        public static string EmptyIf(this string value, string equalityValue, bool ignoreCase = false)
        {
            if (value == null || equalityValue == null)
                return value;

            return value.Equals(equalityValue,
                ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture)
                ? string.Empty
                : value;
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
        /// Return only numeric chars at text
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
        public static string Limit(this string value, int length) => value.SubstringSafe(0, length);

        /// <summary>
        /// Limit <see cref="value"/> with <see cref="length"/> character number safe from right to left.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="length">Max size of return value</param>
        /// <returns></returns>
        public static string LimitReverse(this string value, int length) => value?.SubstringSafe(AggregateExtensions.Max(value.Length - length, 0), length);
    }
}