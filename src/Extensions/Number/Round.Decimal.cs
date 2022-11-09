using System;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    // Round decimal
    public static decimal Round(this decimal value, int digits = 0) => Math.Round(value, digits);

    public static decimal Round(this decimal value, int digits, MidpointRounding mode) =>
        Math.Round(value, digits, mode);

    // Round nullable decimal
    public static decimal? Round(this decimal? value, int digits = 0) => value?.Round(digits);

    public static decimal? Round(this decimal? value, int digits, MidpointRounding mode) =>
        value?.Round(digits, mode);
}