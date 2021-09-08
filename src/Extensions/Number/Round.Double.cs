using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        // Round double
        public static double Round(this double value, int digits = 0) =>
            Convert.ToDouble(Convert.ToDecimal(value).Round(digits));

        public static double Round(this double value, int digits, MidpointRounding mode) =>
            Convert.ToDouble(Convert.ToDecimal(value).Round(digits, mode));

        // Round nullable double
        public static double? Round(this double? value, int digits = 0) => value?.Round(digits);

        public static double? Round(this double? value, int digits, MidpointRounding mode) =>
            value?.Round(digits, mode);
    }
}