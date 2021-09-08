namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Create output variable from execution pipeline method outside of current scope
        /// </summary>
        /// <param name="value"></param>
        /// <param name="output"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T OutVar<T>(this T value, out T output)
        {
            output = value;
            return value;
        }
    }
}