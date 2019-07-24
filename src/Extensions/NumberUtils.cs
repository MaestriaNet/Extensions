using System;

namespace Maestria.Extensions
{
    public static class NumberUtils
    {
        private const float Tolerance = 0.00001f;

        #region NullIf

        public static float? NullIf(this float value, float equalityValue, float tolerance = Tolerance) =>
            Math.Abs(value - equalityValue) < tolerance ? (float?) null : value;

        public static float? NullIf(this float? value, float? equalityValue, float tolerance = Tolerance) =>
            value.HasValue && equalityValue.HasValue
                ? value.Value.NullIf(equalityValue.Value, tolerance)
                : value;

        public static double? NullIf(this double value, double equalityValue, double tolerance = Tolerance) =>
            Math.Abs(value - equalityValue) < tolerance ? (double?) null : value;

        public static double? NullIf(this double? value, double? equalityValue, double tolerance = Tolerance) =>
            value.HasValue && equalityValue.HasValue
                ? value.Value.NullIf(equalityValue.Value, tolerance)
                : value;

        #endregion

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

        #region Round

        public static float Round(this float value) => Convert.ToSingle(Math.Round(value));
        public static float Round(this float value, int digits) => Convert.ToSingle(Math.Round(value, digits));

        public static float Round(this float value, int digits, MidpointRounding mode) =>
            Convert.ToSingle(Math.Round(value, digits, mode));

        public static double Round(this double value) => Math.Round(value);
        public static double Round(this double value, int digits) => Math.Round(value, digits);

        public static double Round(this double value, int digits, MidpointRounding mode) =>
            Math.Round(value, digits, mode);

        public static decimal Round(this decimal value) => Math.Round(value);
        public static decimal Round(this decimal value, int digits) => Math.Round(value, digits);

        public static decimal Round(this decimal value, int digits, MidpointRounding mode) =>
            Math.Round(value, digits, mode);

        #endregion
    }
}