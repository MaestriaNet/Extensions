using System;
using System.Text;

namespace Maestria.Extensions
{
    public static partial class Base64Extensions
    {
        public static string ToBase64(this byte[] plainText) => Convert.ToBase64String(plainText);

        public static string ToBase64(this string plainText, Encoding encoding = null) =>
            ToBase64((encoding ?? Encoding.UTF8).GetBytes(plainText));

        public static byte[] FromBase64(this byte[] base64EncodedData, Encoding encoding = null) =>
            Convert.FromBase64String((encoding ?? Encoding.UTF8).GetString(base64EncodedData));

        public static string FromBase64(this string base64EncodedData, Encoding encoding = null) =>
            (encoding ?? Encoding.UTF8).GetString(Convert.FromBase64String(base64EncodedData));
    }
}