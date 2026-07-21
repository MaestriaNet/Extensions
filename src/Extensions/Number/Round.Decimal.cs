using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    // Round decimal
    public static decimal Round(this decimal value, int decimals = 0) => Math.Round(value, decimals);

    public static decimal Round(this decimal value, int decimals, MidpointRounding mode) =>
        Math.Round(value, decimals, mode);

    // Round nullable decimal
    public static decimal? Round(this decimal? value, int decimals = 0) => value?.Round(decimals);

    public static decimal? Round(this decimal? value, int decimals, MidpointRounding mode) =>
        value?.Round(decimals, mode);
}