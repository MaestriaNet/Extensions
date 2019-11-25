using System;

namespace Maestria.Extensions
{
    public static class RoundExtensions
    {
        #region Round float

        public static float Round(this float value, int digits = 0) =>
            Convert.ToSingle(Convert.ToDecimal(value).Round(digits));

        public static float Round(this float value, int digits, MidpointRounding mode) =>
            Convert.ToSingle(Convert.ToDecimal(value).Round(digits, mode));
        
        public static float RoundUp(this float value, int digits = 0) =>
            Convert.ToSingle(Convert.ToDecimal(value).RoundUp(digits));

        #endregion
        
        #region Round double
        
        public static double Round(this double value, int digits = 0) =>
            Convert.ToDouble(Convert.ToDecimal(value).Round(digits));

        public static double Round(this double value, int digits, MidpointRounding mode) =>
            Convert.ToDouble(Convert.ToDecimal(value).Round(digits, mode));
        
        public static double RoundUp(this double value, int digits = 0) =>
            Convert.ToDouble(Convert.ToDecimal(value).RoundUp(digits));

        #endregion
        
        #region Round decimal
        
        public static decimal Round(this decimal value, int digits = 0) => Math.Round(value, digits);

        public static decimal Round(this decimal value, int digits, MidpointRounding mode) =>
            Math.Round(value, digits, mode);
        
        public static decimal RoundUp(this decimal value, int digits = 0) =>
            Math.Ceiling(value * Convert.ToDecimal(Math.Pow(10, digits))) / Convert.ToDecimal(Math.Pow(10, digits));

        #endregion

        #region Round nullable float
        
        public static float? Round(this float? value, int digits = 0) => value?.Round(digits);
        public static float? Round(this float? value, int digits, MidpointRounding mode) => value?.Round(digits, mode);
        public static float? RoundUp(this float? value, int digits = 0) => value?.RoundUp(digits);
        
        #endregion
        
        #region Round nullable double
        
        public static double? Round(this double? value, int digits = 0) => value?.Round(digits);

        public static double? Round(this double? value, int digits, MidpointRounding mode) =>
            value?.Round(digits, mode);
        
        public static double? RoundUp(this double? value, int digits = 0) => value?.RoundUp(digits);
        
        #endregion
        
        #region Round nullable decimal
        
        public static decimal? Round(this decimal? value, int digits = 0) => value?.Round(digits);

        public static decimal? Round(this decimal? value, int digits, MidpointRounding mode) =>
            value?.Round(digits, mode);
        
        public static decimal? RoundUp(this decimal? value, int digits = 0) => value?.RoundUp(digits);

        #endregion
    }
}