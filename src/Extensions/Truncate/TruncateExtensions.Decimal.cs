using System;

namespace Maestria.Extensions
{
    public static partial class TruncateExtensions
    {
        public static decimal Truncate(this decimal value, int digits = 0) =>
            Math.Floor(value * Convert.ToDecimal(Math.Pow(10, digits))) / Convert.ToDecimal(Math.Pow(10, digits));

        public static decimal? Truncate(this decimal? value, int digits = 0) => value?.Truncate(digits);
    }
}