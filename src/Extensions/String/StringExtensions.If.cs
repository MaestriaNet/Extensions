using System;
using System.Globalization;

namespace Maestria.Extensions
{
    public partial class StringExtensions
    {
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
        /// Return empty string if <paramref name="value"/> is null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EmptyIfNull(this string value) => value == null ? string.Empty : value;

        /// <summary>
        /// Return empty string if <paramref name="value"/> is null or white space
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EmptyIfNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value) ? string.Empty : value;

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
    }
}