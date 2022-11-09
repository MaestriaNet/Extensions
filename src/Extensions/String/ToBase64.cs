using System;
using System.Text;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="encoding">Default is UTF8 when is null</param>
        /// <returns></returns>
        public static string ToBase64(this string plainText, Encoding? encoding = null) =>
            ToBase64((encoding ?? Encoding.UTF8).GetBytes(plainText));

        public static string ToBase64(this byte[] plainText) => Convert.ToBase64String(plainText);
    }
}