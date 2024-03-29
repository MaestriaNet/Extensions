using System.Text;
using System.Web;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    public static string UrlDecode(this string? value) => value != null ? HttpUtility.UrlDecode(value) : string.Empty;
    public static string UrlDecode(this string? value, Encoding encoding) => value != null ? HttpUtility.UrlDecode(value, encoding) : string.Empty;
}