using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        // RoundUp double
        public static double RoundUp(this double value, int digits = 0) =>
            Convert.ToDouble(Convert.ToDecimal(value).RoundUp(digits));

        // RoundUp nullable double
        public static double? RoundUp(this double? value, int digits = 0) => value?.RoundUp(digits);
    }
}