using System;

namespace Maestria.Extensions
{
    public static partial class RoundExtensions
    {
        #region Round decimal
        
        public static decimal Round(this decimal value, int digits = 0) => Math.Round(value, digits);

        public static decimal Round(this decimal value, int digits, MidpointRounding mode) =>
            Math.Round(value, digits, mode);
        
        public static decimal RoundUp(this decimal value, int digits = 0) =>
            Math.Ceiling(value * Convert.ToDecimal(Math.Pow(10, digits))) / Convert.ToDecimal(Math.Pow(10, digits));

        #endregion

        #region Round nullable decimal
        
        public static decimal? Round(this decimal? value, int digits = 0) => value?.Round(digits);

        public static decimal? Round(this decimal? value, int digits, MidpointRounding mode) =>
            value?.Round(digits, mode);
        
        public static decimal? RoundUp(this decimal? value, int digits = 0) => value?.RoundUp(digits);

        #endregion
    }
}