using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static float? NullIf(this float value, float equalityValue) =>
            NullIf(value, equalityValue, GlobalSettings.Properties.FloatAndDoubleTolerance);

        public static float? NullIf(this float value, float equalityValue, float tolerance) =>
            Math.Abs(value - equalityValue) < tolerance ? (float?) null : value;

        public static float? NullIf(this float? value, float? equalityValue) =>
            NullIf(value, equalityValue, GlobalSettings.Properties.FloatAndDoubleTolerance);

        public static float? NullIf(this float? value, float? equalityValue, float tolerance) =>
            value.HasValue && equalityValue.HasValue
                ? value.Value.NullIf(equalityValue.Value, tolerance)
                : value;
    }
}