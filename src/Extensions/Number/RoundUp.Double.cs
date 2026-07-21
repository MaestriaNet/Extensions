using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    // RoundUp double
    public static double RoundUp(this double value, int decimals = 0) =>
        Convert.ToDouble(Convert.ToDecimal(value).RoundUp(decimals));

    // RoundUp nullable double
    public static double? RoundUp(this double? value, int decimals = 0) => value?.RoundUp(decimals);
}