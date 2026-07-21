using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    // Round float
    public static float Round(this float value, int decimals = 0) =>
        Convert.ToSingle(Convert.ToDecimal(value).Round(decimals));

    public static float Round(this float value, int decimals, MidpointRounding mode) =>
        Convert.ToSingle(Convert.ToDecimal(value).Round(decimals, mode));

    // Round nullable float
    public static float? Round(this float? value, int decimals = 0) => value?.Round(decimals);
    public static float? Round(this float? value, int decimals, MidpointRounding mode) => value?.Round(decimals, mode);
}