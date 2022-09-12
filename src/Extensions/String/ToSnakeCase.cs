using System.Linq;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        public static string ToSnakeCase(this string value)
        {
            if (value.IsNullOrWhiteSpace())
                return value;
            return value.Select((x, i) =>
            {
                if (i > 0 && value[i - 1] != '_')
                {
                    if (char.IsUpper(x))
                        return "_" + x.ToString().ToLower();
                    else if (char.IsDigit(x) && !char.IsDigit(value[i - 1]))
                        return "_" + x.ToString().ToLower();
                }

                return x.ToString().ToLower();
            }).Join("");
        }
    }
}