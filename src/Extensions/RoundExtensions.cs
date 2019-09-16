using System;

namespace Maestria.Extensions
{
    public static class RoundExtensions
    {
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

        #region Round nullable

        public static float? Round(this float? value) => value?.Round();
        public static float? Round(this float? value, int digits) => value?.Round(digits);
        public static float? Round(this float? value, int digits, MidpointRounding mode) => value?.Round(digits, mode);

        public static double? Round(this double? value) => value?.Round();
        public static double? Round(this double? value, int digits) => value?.Round(digits);

        public static double? Round(this double? value, int digits, MidpointRounding mode) =>
            value?.Round(digits, mode);

        public static decimal? Round(this decimal? value) => value?.Round();
        public static decimal? Round(this decimal? value, int digits) => value?.Round(digits);

        public static decimal? Round(this decimal? value, int digits, MidpointRounding mode) =>
            value?.Round(digits, mode);

        #endregion
    }
}