using System;

namespace Maestria.Extensions
{
    public static class TruncateExtensions
    {
        #region Truncate

        public static float Truncate(this float value, int digits = 0) =>
            Convert.ToSingle(Convert.ToDecimal(value).Truncate(digits));

        public static double Truncate(this double value, int digits = 0) =>
            Convert.ToDouble(Convert.ToDecimal(value).Truncate(digits));

        public static decimal Truncate(this decimal value, int digits = 0) =>
            Math.Floor(value * Convert.ToDecimal(Math.Pow(10, digits))) / Convert.ToDecimal(Math.Pow(10, digits));

        #endregion

        #region Truncate nullable
        
        public static float? Truncate(this float? value, int digits = 0) => value?.Truncate(digits);
        public static double? Truncate(this double? value, int digits = 0) => value?.Truncate(digits);
        public static decimal? Truncate(this decimal? value, int digits = 0) => value?.Truncate(digits);

        #endregion
    }
}