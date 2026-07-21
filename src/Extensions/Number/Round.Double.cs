using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    // Round double
    public static double Round(this double value, int decimals = 0) =>
        Convert.ToDouble(Convert.ToDecimal(value).Round(decimals));

    public static double Round(this double value, int decimals, MidpointRounding mode) =>
        Convert.ToDouble(Convert.ToDecimal(value).Round(decimals, mode));

    // Round nullable double
    public static double? Round(this double? value, int decimals = 0) => value?.Round(decimals);

    public static double? Round(this double? value, int decimals, MidpointRounding mode) =>
        value?.Round(decimals, mode);
}