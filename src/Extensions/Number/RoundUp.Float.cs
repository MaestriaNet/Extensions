using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    // RoundUp float
    public static float RoundUp(this float value, int decimals = 0) =>
        Convert.ToSingle(Convert.ToDecimal(value).RoundUp(decimals));

    // RoundUp nullable float
    public static float? RoundUp(this float? value, int decimals = 0) => value?.RoundUp(decimals);
}