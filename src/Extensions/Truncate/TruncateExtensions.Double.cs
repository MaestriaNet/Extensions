using System;

namespace Maestria.Extensions
{
    public static partial class TruncateExtensions
    {
        public static double Truncate(this double value, int digits = 0) =>
            Convert.ToDouble(Convert.ToDecimal(value).Truncate(digits));

        public static double? Truncate(this double? value, int digits = 0) => value?.Truncate(digits);
    }
}