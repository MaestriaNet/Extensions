using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static float Truncate(this float value, int digits = 0) =>
            Convert.ToSingle(Convert.ToDecimal(value).Truncate(digits));

        public static float? Truncate(this float? value, int digits = 0) => value?.Truncate(digits);
    }
}