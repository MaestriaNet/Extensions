using System;
using System.Text;

namespace Maestria.Extensions
{
    public class Base64Extensions
    {
        public static string Encode(byte[] plainText) => Convert.ToBase64String(plainText);

        public static string Encode(string plainText, Encoding encoding = null) =>
            Encode((encoding ?? Encoding.UTF8).GetBytes(plainText));

        public static byte[] Decode(byte[] base64EncodedData, Encoding encoding = null) =>
            Convert.FromBase64String((encoding ?? Encoding.UTF8).GetString(base64EncodedData));

        public static string Decode(string base64EncodedData, Encoding encoding = null) =>
            (encoding ?? Encoding.UTF8).GetString(Convert.FromBase64String(base64EncodedData));
    }
}