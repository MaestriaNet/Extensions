using System.Linq;
using System.Text.RegularExpressions;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="value"></param>
    /// <returns>If input is null value, returns is empty string</returns>
    public static string ToKebabCase(this string? value)
    {
        if (value.IsNullOrWhiteSpace())
            return value ?? string.Empty;

        value = value.Replace('_', '-');
        return value.Select((x, i) =>
        {
            if (i > 0 && value![i - 1] != '-')
            {
                if (char.IsUpper(x))
                    return "-" + x.ToString().ToLower();
                else if (char.IsDigit(x) && !char.IsDigit(value[i - 1]))
                    return "-" + x.ToString().ToLower();
            }

            return x.ToString().ToLower();
        }).Join("");
    }
}