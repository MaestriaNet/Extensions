using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Maestria.Extensions
{
    public static partial class MaestriaExtensions
    {
        /// <summary>
        /// Retuning value of attribute <see cref="DescriptionAttribute"/> or property Description of <see cref="DisplayAttribute"/>, when not present attribute returns is enum text
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            if (value == null) return string.Empty;
            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            var descriptionAttr = field.GetCustomAttribute<DescriptionAttribute>();
            if (descriptionAttr != null)
                return descriptionAttr.Description;

            var displayAttr = field.GetCustomAttribute<DisplayAttribute>();
            if (displayAttr != null)
                return displayAttr.Description;

            return value.ToString();
        }
    }
}