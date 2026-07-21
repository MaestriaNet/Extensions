using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    // RoundUp decimal
    public static decimal RoundUp(this decimal value, int decimals = 0) =>
        Math.Ceiling(value * Convert.ToDecimal(Math.Pow(10, decimals))) / Convert.ToDecimal(Math.Pow(10, decimals));

    // RoundUp nullable decimal
    public static decimal? RoundUp(this decimal? value, int decimals = 0) => value?.RoundUp(decimals);
}