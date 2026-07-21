using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static float Truncate(this float value, int decimals = 0) =>
        Convert.ToSingle(Convert.ToDecimal(value).Truncate(decimals));

    public static float? Truncate(this float? value, int decimals = 0) => value?.Truncate(decimals);
}