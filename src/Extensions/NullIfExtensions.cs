using System;
using System.Collections.Generic;

namespace Maestria.Extensions
{
    public static class NullIfExtensions
    {
        private const float Tolerance = 0.00001f;

        #region Default

        public static T? NullIf<T>(this T value, T equalityValue) where T : struct =>
            EqualityComparer<T>.Default.Equals(value, equalityValue) ? (T?) null : value;

        public static T NullIf<T>(this object value, T equalityValue) where T : class =>
            value == equalityValue ? null : (T) value;

        public static T? NullIfIn<T>(this T value, params T[] values) where T : struct, IComparable =>
            value.In(values) ? (T? )null : value;

        public static T? NullIfBetween<T>(this T value, T starting, T ending) where T : struct, IComparable =>
            value.Between(starting, ending) ? (T? )null : value;

        #endregion

        #region Float

        public static float? NullIf(this float value, float equalityValue, float tolerance = Tolerance) =>
            Math.Abs(value - equalityValue) < tolerance ? (float?) null : value;

        public static float? NullIf(this float? value, float? equalityValue, float tolerance = Tolerance) =>
            value.HasValue && equalityValue.HasValue
                ? value.Value.NullIf(equalityValue.Value, tolerance)
                : value;

        #endregion

        #region Double

        public static double? NullIf(this double value, double equalityValue, double tolerance = Tolerance) =>
            Math.Abs(value - equalityValue) < tolerance ? (double?) null : value;

        public static double? NullIf(this double? value, double? equalityValue, double tolerance = Tolerance) =>
            value.HasValue && equalityValue.HasValue
                ? value.Value.NullIf(equalityValue.Value, tolerance)
                : value;

        #endregion
    }
}