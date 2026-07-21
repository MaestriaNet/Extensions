using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static double Truncate(this double value, int decimals = 0) =>
        Convert.ToDouble(Convert.ToDecimal(value).Truncate(decimals));

    public static double? Truncate(this double? value, int decimals = 0) => value?.Truncate(decimals);
}