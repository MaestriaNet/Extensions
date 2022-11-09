namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Check value is null
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNull([NotNullWhen(false)] this object? value) => value == null;
}