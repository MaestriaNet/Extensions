using System;
using System.Collections.Generic;
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
            if (value == null || equality == null) return value;
            return value.StartsWith(equality, ignoreCase, CultureInfo.InvariantCulture)
                ? value.Remove(0, equality.Length)
                : value;
        }

        /// <summary>
        /// Remove prefix (left part) if text beginning with equality value. The part to remove is exactly checked value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and remove from text, if text beginning equals this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string RemoveIfStartsWith(this string value, char equality, bool ignoreCase = true) => value.RemoveIfStartsWith(equality.ToString(), ignoreCase);

        /// <summary>
        /// Remove suffix (right part) if text ends with equality value. The part to remove is exactly checked value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and remove from text, if text end equals this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string RemoveIfEndsWith(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null || equality == null) return value;
            return value.EndsWith(equality, ignoreCase, CultureInfo.InvariantCulture)
                ? value.Remove(value.Length - equality.Length, equality.Length)
                : value;
        }

        /// <summary>
        /// Remove suffix (right part) if text ends with equality value. The part to remove is exactly checked value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and remove from text, if text end equals this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string RemoveIfEndsWith(this string value, char equality, bool ignoreCase = true) => value.RemoveIfEndsWith(equality.ToString(), ignoreCase);

        /// <summary>
        /// Add value to start of text if the text not beginning with value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and concat to start of text when text not beginning with this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string AddToLeftIfNotStartsWith(this string value, string equality, bool ignoreCase = true)
        {
            if (value == null) return equality;
            if (equality == null) return value;
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
        public static string AddToLeftIfNotStartsWith(this string value, char equality, bool ignoreCase = true) => value.AddToLeftIfNotStartsWith(equality.ToString(), ignoreCase);

        /// <summary>
        /// Add value to end of text if the text not end with value.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="equality">To check and concat to end of text when text not end with this value</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns></returns>
        public static string AddToRightIfNotEndsWith(this string value, string equality, bool ignoreCase = true)
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
        public static string AddToRightIfNotEndsWith(this string value, char equality, bool ignoreCase = true) => value.AddToRightIfNotEndsWith(equality.ToString(), ignoreCase);

        /// <summary>
        /// Add value to beginning of text if the text is not null or white space.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="prefix">To concat at the beginning of text</param>
        /// <returns></returns>
        public static string AddToLeftIfHasValue(this string value, string prefix) =>
            value.HasValue() ? prefix + value : value;

        /// <summary>
        /// Add value to beginning of text if the text is not null or white space.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="prefix">To concat at the beginning of text</param>
        /// <returns></returns>
        public static string AddToLeftIfHasValue(this string value, char prefix) => value.AddToLeftIfHasValue(prefix.ToString());

        /// <summary>
        /// Add value to ends of text if the text is not null or white space.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="suffix">To concat at the ending of text</param>
        /// <returns></returns>
        public static string AddToRightIfHasValue(this string value, string suffix) =>
            value.HasValue() ? value + suffix : value;

        /// <summary>
        /// Add value to ends of text if the text is not null or white space.
        /// </summary>
        /// <param name="value">Text to manipulate</param>
        /// <param name="suffix">To concat at the ending of text</param>
        /// <returns></returns>
        public static string AddToRightIfHasValue(this string value, char suffix) => value.AddToRightIfHasValue(suffix.ToString());

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
            if (value.IsNullOrWhiteSpace() || args == null || args.Length == 0) return value;
            return string.Format(value, args);
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

        #endregion

        #region Text patterns

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

        #endregion

        /// <summary>
        /// Extract substring before first occurrence of text pattern. When not found returns null.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="find">Find text pattern</param>
        /// <param name="autoTrim">Apply trim on result</param>
        /// <returns></returns>
        public static string SubstringBeforeFirstOccurrence(this string value, string find, bool autoTrim = true)
        {
            if (value == null) return null;
            var index = value.IndexOf(find);
            if (index > 0)
                return autoTrim
                    ? value.Substring(0, index).Trim()
                    : value.Substring(0, index);
            return null;
        }

        /// <summary>
        /// Extract substring after first occurrence of text pattern. When not found returns null.
        /// </summary>
        /// <param name="value">Full text</param>
        /// <param name="find">Find text pattern</param>
        /// /// <param name="autoTrim">Apply trim on result</param>
        /// <returns></returns>
        public static string SubstringAfterFirstOccurrence(this string value, string find, bool autoTrim = true)
        {
            if (value == null) return null;
            var index = value.IndexOf(find);
            if (index > 0)
                return autoTrim
                    ? value.Substring(index + find.Length, value.Length - index - find.Length).Trim()
                    : value.Substring(index + find.Length, value.Length - index - find.Length);
            return null;
        }
    }
}