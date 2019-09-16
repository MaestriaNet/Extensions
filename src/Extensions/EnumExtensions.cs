using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Maestria.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Retuning value of attribute <see cref="DisplayNameAttribute"/> or property Name of <see cref="DisplayAttribute"/>, when not present attribute returns is enum text
        /// </summary>
        /// <param name="value">Tipo enum para buscar atributo</param>
        /// <returns>Propriedade Name do atributo</returns>
        public static string GetDisplayName(this Enum value)
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

        /// <summary>
        /// Retuning value of attribute <see cref="DescriptionAttribute"/> or property Description of <see cref="DisplayAttribute"/>, when not present attribute returns is enum text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T value)
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

        /// <summary>
        /// Result array with all itens in enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] GetValues<T>()
            where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            var result = new T[values.Length];

            var i = 0;
            foreach (var item in values)
            {
                result[i] = (T) item;
                i++;
            }

            return result;
        }
    }
}