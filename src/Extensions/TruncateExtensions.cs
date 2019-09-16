using System;

namespace Maestria.Extensions
{
    public static class TruncateExtensions
    {
        #region Truncate

        public static float Truncate(this float value) => Convert.ToSingle(Math.Truncate(value));

        public static float Truncate(this float value, int digits) =>
            Convert.ToSingle(Math.Truncate(value * Math.Pow(10, digits)) / Math.Pow(10, digits));

        public static double Truncate(this double value) => Math.Truncate(value);

        public static double Truncate(this double value, int digits) =>
            Math.Truncate(value * Math.Pow(10, digits)) / Math.Pow(10, digits);

        public static decimal Truncate(this decimal value) => Math.Truncate(value);

        public static decimal Truncate(this decimal value, int digits) =>
            Math.Truncate(value * Convert.ToDecimal(Math.Pow(10, digits))) / Convert.ToDecimal(Math.Pow(10, digits));

        #endregion

        #region Truncate nullable

        public static float? Truncate(this float? value) => value?.Truncate();

        public static float? Truncate(this float? value, int digits) => value?.Truncate(digits);

        public static double? Truncate(this double? value) => value?.Truncate();

        public static double? Truncate(this double? value, int digits) => value?.Truncate(digits);

        public static decimal? Truncate(this decimal? value) => value?.Truncate();

        public static decimal? Truncate(this decimal? value, int digits) => value?.Truncate(digits);

        #endregion
    }
}