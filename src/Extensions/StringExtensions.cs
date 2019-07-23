using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Maestria.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex NonDigitsRegex = new Regex(@"[^\d]+");

        #region String check and manipulate

        /// <summary>
        /// Remove prefix (left part) if text beginning with equality value. The part to remove is exactly checked value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and remove from text, if text beginning equals this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string RemoveIfStartsWith(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null || equality == null)
                return value;

            return value.StartsWith(equality, ignoreCase, CultureInfo.InvariantCulture)
                ? value.Remove(0, equality.Length)
                : value;
        }

        /// <summary>
        /// Remove suffix (right part) if text ends with equality value. The part to remove is exactly checked value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and remove from text, if text end equals this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string RemoveIfEndsWith(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null || equality == null)
                return value;

            return value.EndsWith(equality, ignoreCase, CultureInfo.InvariantCulture)
                ? value.Remove(value.Length - equality.Length, equality.Length)
                : value;
        }

        /// <summary>
        /// Add value to start of text if the text not beginning with value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and concat to start of text when text not beginning with this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string AddToLeftIfNotStartsWith(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null || equality == null)
                return value;

            return value.StartsWith(equality, ignoreCase, CultureInfo.InvariantCulture)
                ? value
                : equality + value;
        }

        /// <summary>
        /// Add value to end of text if the text not end with value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and concat to end of text when text not end with this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string AddToRightIfNotEndsWith(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null || equality == null)
                return value;

            return value.EndsWith(equality, ignoreCase, CultureInfo.InvariantCulture)
                ? value
                : value + equality;
        }

        /// <summary>
        /// Add value to beginning of text if the text is not null or white space.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="prefix">To concat at the beginning of text</param>
        /// <returns></returns>
        public static string AddToLeftIfHasValue(this string value, string prefix) =>
            value.HasValue() ? prefix + value : value;

        /// <summary>
        /// Add value to ends of text if the text is not null or white space.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="prefix">To concat at the ending of text</param>
        /// <returns></returns>
        public static string AddToRightIfHasValue(this string value, string suffix) =>
            value.HasValue() ? value + suffix : value;

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
        /// <param name="value"></param>
        /// <returns></returns>
        public static string OnlyNumbers(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            return NonDigitsRegex.Replace(value, "");
        }

        #endregion

        #region Value check

        /// <summary>
        /// Check text is null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>
        /// Check text is null or white space
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Check if text is not null and not white space
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasValue(this string value) => !string.IsNullOrWhiteSpace(value);

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
        /// Return <paramref name="default"/> text argument if <paramref name="value"/> is null or empty
        /// </summary>
        /// <param name="value">Current text value</param>
        /// <param name="default">Value to return if <paramref name="value"/> is null or empty</param>
        /// <returns></returns>
        public static string IfNullOrEmpty(this string value, string @default) =>
            value.IsNullOrEmpty() ? @default : value;

        /// <summary>
        /// Return <paramref name="default"/> text argument if <paramref name="value"/> is null or white space
        /// </summary>
        /// <param name="value">Current text value</param>
        /// <param name="default">Value to return if <paramref name="value"/> is null or white space</param>
        /// <returns></returns>
        public static string IfNullOrWhiteSpace(this string value, string @default) =>
            value.IsNullOrWhiteSpace() ? @default : value;

        /// <summary>
        /// Return null if <paramref name="value"/> is empty string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string NullIfEmpty(this string value) => value.IsNullOrEmpty() ? null : value;

        /// <summary>
        /// Return null if <paramref name="value"/> is white space
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string NullIfWhiteSpace(this string value) => value.IsNullOrWhiteSpace() ? null : value;

        /// <summary>
        /// Return null if <paramref name="value"/> is equals to <paramref name="equalityValue"/>
        /// </summary>
        /// <param name="value">Current text</param>
        /// <param name="equalityValue">Text to compare with <paramref name="value"/> and return null if equals</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns>null if <paramref name="value"/> is equals to <paramref name="equalityValue"/></returns>
        public static string NullIf(this string value, string equalityValue, bool ignoreCase = true)
        {
            if (value == null || equalityValue == null)
                return value;

            return value.Equals(equalityValue,
                ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture)
                ? null
                : value;
        }

        #endregion

        #region Clear text

        public static string RemoveAccents(this string text)
        {
            var result = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (var letter in arrayText)
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    result.Append(letter);

            return result.ToString();
        }

        #endregion
    }
}