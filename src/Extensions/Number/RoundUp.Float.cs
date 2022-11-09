using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    // RoundUp float
    public static float RoundUp(this float value, int digits = 0) =>
        Convert.ToSingle(Convert.ToDecimal(value).RoundUp(digits));

    // RoundUp nullable float
    public static float? RoundUp(this float? value, int digits = 0) => value?.RoundUp(digits);
}