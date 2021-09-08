namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Return <paramref name="default"/> if argument <paramref name="value"/> is null/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="default"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T IfNull<T>(this T? value, T @default) where T : struct => value ?? @default;

        /// <summary>
        /// Return <paramref name="default"/> if argument <paramref name="value"/> is null/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="default"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T IfNull<T>(this T value, T @default) where T : class => value ?? @default;
    }
}
