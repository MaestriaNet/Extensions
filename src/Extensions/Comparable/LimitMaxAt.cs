using System;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// If <paramref name="maxValue"/> it's bigger of <paramref name="value"/> return <paramref name="maxValue"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxValue">Highest value limit</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T LimitMaxAt<T> (this T value, T maxValue) where T : IComparable => value.CompareTo(maxValue) > 0 ? maxValue : value;
    }
}