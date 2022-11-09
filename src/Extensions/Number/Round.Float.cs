using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    // Round float
    public static float Round(this float value, int digits = 0) =>
        Convert.ToSingle(Convert.ToDecimal(value).Round(digits));

    public static float Round(this float value, int digits, MidpointRounding mode) =>
        Convert.ToSingle(Convert.ToDecimal(value).Round(digits, mode));

    // Round nullable float
    public static float? Round(this float? value, int digits = 0) => value?.Round(digits);
    public static float? Round(this float? value, int digits, MidpointRounding mode) => value?.Round(digits, mode);
}