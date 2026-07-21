using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static decimal Truncate(this decimal value, int decimals = 0) =>
        Math.Floor(value * Convert.ToDecimal(Math.Pow(10, decimals))) / Convert.ToDecimal(Math.Pow(10, decimals));

    public static decimal? Truncate(this decimal? value, int decimals = 0) => value?.Truncate(decimals);
}