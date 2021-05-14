using System;

namespace Maestria.Extensions
{
    public static partial class RoundExtensions
    {
        #region Round float

        public static float Round(this float value, int digits = 0) =>
            Convert.ToSingle(Convert.ToDecimal(value).Round(digits));

        public static float Round(this float value, int digits, MidpointRounding mode) =>
            Convert.ToSingle(Convert.ToDecimal(value).Round(digits, mode));
        
        public static float RoundUp(this float value, int digits = 0) =>
            Convert.ToSingle(Convert.ToDecimal(value).RoundUp(digits));

        #endregion

        #region Round nullable float
        
        public static float? Round(this float? value, int digits = 0) => value?.Round(digits);
        public static float? Round(this float? value, int digits, MidpointRounding mode) => value?.Round(digits, mode);
        public static float? RoundUp(this float? value, int digits = 0) => value?.RoundUp(digits);
        
        #endregion
    }
}