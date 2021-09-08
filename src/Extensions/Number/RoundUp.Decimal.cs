using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        // RoundUp decimal
        public static decimal RoundUp(this decimal value, int digits = 0) =>
            Math.Ceiling(value * Convert.ToDecimal(Math.Pow(10, digits))) / Convert.ToDecimal(Math.Pow(10, digits));

        // RoundUp nullable decimal
        public static decimal? RoundUp(this decimal? value, int digits = 0) => value?.RoundUp(digits);
    }
}