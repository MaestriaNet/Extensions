using System;

namespace Maestria.Extensions
{
    public static partial class StringExtensions
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
    }
}