using System;

namespace Maestria.Extensions
{
    public static partial class EnumExtensions
    {
        /// <summary>
        /// Result array with all itens in enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] GetValues<T>()
            where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            var result = new T[values.Length];

            var i = 0;
            foreach (var item in values)
            {
                result[i] = (T) item;
                i++;
            }

            return result;
        }

        /// <summary>
        /// Result array with all itens in enum
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Enum[] GetValues(Type enumType)
        {
            var values = Enum.GetValues(enumType);
            var result = new Enum[values.Length];

            var i = 0;
            foreach (var item in values)
            {
                result[i] = (Enum) item;
                i++;
            }

            return result;
        }
    }
}