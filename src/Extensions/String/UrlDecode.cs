using System.Text;
using System.Web;

namespace src.Extensions.String
{
    public static partial class MaestriaExtensions
    {
        public static string? UrlDecode(this string? value) => value != null ? HttpUtility.UrlDecode(value) : null;
        public static string? UrlDecode(this string? value, Encoding encoding) => value != null ? HttpUtility.UrlDecode(value, encoding) : null;
    }
}