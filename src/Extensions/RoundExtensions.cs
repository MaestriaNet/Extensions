using System;

namespace Maestria.Extensions
{
    public static class RoundExtensions
    {
        #region Round float

        public static float Round(this float value) => value.Round(0);

        public static float Round(this float value, int digits) =>
            Convert.ToSingle(Math.Round(Convert.ToDecimal(value), digits));

        public static float Round(this float value, int digits, MidpointRounding mode) =>
            Convert.ToSingle(Math.Round(Convert.ToDecimal(value), digits, mode));
        
        #endregion
        
        #region Round double

        public static double Round(this double value) => value.Round(0);

        public static double Round(this double value, int digits) =>
            Convert.ToDouble(Math.Round(Convert.ToDecimal(value), digits));

        public static double Round(this double value, int digits, MidpointRounding mode) =>
            Convert.ToDouble(Math.Round(Convert.ToDecimal(value), digits, mode));
        
        #endregion
        
        #region Round decimal

        public static decimal Round(this decimal value) => value.Round(0);
        public static decimal Round(this decimal value, int digits) => Math.Round(value, digits);

        public static decimal Round(this decimal value, int digits, MidpointRounding mode) =>
            Math.Round(value, digits, mode);

        #endregion

        #region Round nullable float

        public static float? Round(this float? value) => value?.Round();
        public static float? Round(this float? value, int digits) => value?.Round(digits);
        public static float? Round(this float? value, int digits, MidpointRounding mode) => value?.Round(digits, mode);
        
        #endregion
        
        #region Round nullable double

        public static double? Round(this double? value) => value?.Round();
        public static double? Round(this double? value, int digits) => value?.Round(digits);

        public static double? Round(this double? value, int digits, MidpointRounding mode) =>
            value?.Round(digits, mode);
        
        #endregion
        
        #region Round nullable decimal

        public static decimal? Round(this decimal? value) => value?.Round();
        public static decimal? Round(this decimal? value, int digits) => value?.Round(digits);

        public static decimal? Round(this decimal? value, int digits, MidpointRounding mode) =>
            value?.Round(digits, mode);

        #endregion
    }
}