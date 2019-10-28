using System;
using System.Collections.Generic;

namespace Maestria.Extensions
{
    public static class NullIfExtensions
    {
        #region Default

        public static T? NullIf<T>(this T value, T equalityValue) where T : struct =>
            EqualityComparer<T>.Default.Equals(value, equalityValue) ? (T?) null : value;

        public static T? NullIf<T>(this T? value, T? equalityValue) where T : struct =>
            EqualityComparer<T?>.Default.Equals(value, equalityValue) ? (T?) null : value;

        public static T NullIf<T>(this object value, T equalityValue) where T : class =>
            value != null && equalityValue != null && value.Equals(equalityValue) ? null : (T) value;

        public static T? NullIfIn<T>(this T value, params T[] values) where T : struct, IComparable =>
            value.In(values) ? (T? )null : value;

        public static T? NullIfBetween<T>(this T value, T starting, T ending) where T : struct, IComparable =>
            value.Between(starting, ending) ? (T? )null : value;

        #endregion

        #region Float

        public static float? NullIf(this float value, float equalityValue) =>
            NullIf(value, equalityValue, GlobalSettings.Properties.FloatAndDoubleTolerance);

        public static float? NullIf(this float value, float equalityValue, float tolerance) =>
            Math.Abs(value - equalityValue) < tolerance ? (float?) null : value;

        public static float? NullIf(this float? value, float? equalityValue) =>
            NullIf(value, equalityValue, GlobalSettings.Properties.FloatAndDoubleTolerance);

        public static float? NullIf(this float? value, float? equalityValue, float tolerance) =>
            value.HasValue && equalityValue.HasValue
                ? value.Value.NullIf(equalityValue.Value, tolerance)
                : value;

        #endregion

        #region Double

        public static double? NullIf(this double value, double equalityValue) =>
            NullIf(value, equalityValue, GlobalSettings.Properties.FloatAndDoubleTolerance);

        public static double? NullIf(this double value, double equalityValue, double tolerance) =>
            Math.Abs(value - equalityValue) < tolerance ? (double?) null : value;

        public static double? NullIf(this double? value, double? equalityValue) =>
            NullIf(value, equalityValue, GlobalSettings.Properties.FloatAndDoubleTolerance);

        public static double? NullIf(this double? value, double? equalityValue, double tolerance) =>
            value.HasValue && equalityValue.HasValue
                ? value.Value.NullIf(equalityValue.Value, tolerance)
                : value;

        #endregion

        #region Decimal

        public static decimal? NullIf(this decimal value, decimal equalityValue, decimal tolerance) =>
            Math.Abs(value - equalityValue) < tolerance ? (decimal?) null : value;

        public static decimal? NullIf(this decimal? value, decimal? equalityValue, decimal tolerance) =>
            value.HasValue && equalityValue.HasValue
                ? value.Value.NullIf(equalityValue.Value, tolerance)
                : value;

        #endregion

        #region String

        /// <summary>
        /// Return null if <paramref name="value"/> is equals to <paramref name="equalityValue"/>
        /// </summary>
        /// <param name="value">Current text</param>
        /// <param name="equalityValue">Text to compare with <paramref name="value"/> and return null if equals</param>
        /// <param name="ignoreCase">Ignore char case at the invariant culture</param>
        /// <returns>null if <paramref name="value"/> is equals to <paramref name="equalityValue"/></returns>
        public static string NullIf(this string value, string equalityValue, bool ignoreCase = false)
        {
            if (value == null || equalityValue == null)
                return value;

            return value.Equals(equalityValue,
                ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture)
                ? null
                : value;
        }

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

        #endregion
    }
}