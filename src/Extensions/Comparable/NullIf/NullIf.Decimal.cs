using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static decimal? NullIf(this decimal value, decimal equalityValue, decimal tolerance) =>
            Math.Abs(value - equalityValue) < tolerance ? (decimal?) null : value;

        public static decimal? NullIf(this decimal? value, decimal? equalityValue, decimal tolerance) =>
            value.HasValue && equalityValue.HasValue
                ? value.Value.NullIf(equalityValue.Value, tolerance)
                : value;
    }
}