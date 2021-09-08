using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static double? NullIf(this double value, double equalityValue) =>
            NullIf(value, equalityValue, GlobalSettings.Properties.FloatAndDoubleTolerance);

        public static double? NullIf(this double value, double equalityValue, double tolerance) =>
            Math.Abs(value - equalityValue) < tolerance ? (double?) null : value;

        public static double? NullIf(this double? value, double? equalityValue) =>
            NullIf(value, equalityValue, GlobalSettings.Properties.FloatAndDoubleTolerance);

        public static double? NullIf(this double? value, double? equalityValue, double tolerance) =>
            value.HasValue && equalityValue.HasValue
                ? value.Value.NullIf(equalityValue.Value, tolerance)
                : value;
    }
}