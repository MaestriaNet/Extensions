using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Maestria.Extensions;

public static partial class MaestriaExtensions
{
    /// <summary>
    /// Retuning value of attribute <see cref="DisplayNameAttribute"/> or property Name of <see cref="DisplayAttribute"/>, when not present attribute returns is enum text
    /// </summary>
    /// <param name="value">Tipo enum para buscar atributo</param>
    /// <returns>Propriedade Name do atributo</returns>
    public static string? GetDisplayName(this Enum value)
    {
        if (value == null) return string.Empty;
        var field = value.GetType().GetField(value.ToString());
        if (field == null) return value.ToString();

        var nameAtt = field.GetCustomAttribute<DisplayNameAttribute>();
        if (nameAtt != null)
            return nameAtt.DisplayName;

        var displayAttr = field.GetCustomAttribute<DisplayAttribute>();
        if (displayAttr != null)
            return displayAttr.Name;

        return value.ToString();
    }
}