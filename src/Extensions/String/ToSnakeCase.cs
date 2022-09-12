using System.Linq;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        // public static string ToSnakeCase(this string value) =>
        //     string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) && value[i - 1] != '_' ? "_" + x.ToString().ToLower() : x.ToString().ToLower()));

        public static string ToSnakeCase(this string value) =>
            string.Concat(value.Select((x, i) =>
            {
                // return i > 0 && char.IsUpper(x) && value[i - 1] != '_' ? "_" + x.ToString().ToLower() : x.ToString().ToLower();
                if (i > 0 && value[i - 1] != '_')
                {
                    if (char.IsUpper(x))
                        return "_" + x.ToString().ToLower();
                    else if (char.IsDigit(x) && !char.IsDigit(value[i - 1]))
                        return "_" + x.ToString().ToLower();
                }

                return x.ToString().ToLower();
            }));
    }
}