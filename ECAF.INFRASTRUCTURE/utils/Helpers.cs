using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ECAF.INFRASTRUCTURE.utils
{
    public class Helpers
    {
        public static string GetEnumDescription<TEnum>(int value) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), value))
            {
                TEnum enumValue = (TEnum)(object)value;
                return enumValue.GetDescription();
            }

            return "Invalid value";
        }
        public static SelectList GetEnumSelectList<TEnum>() where TEnum : Enum
        {
            var items = Enum.GetValues(typeof(TEnum))
                            .Cast<TEnum>()
                            .Select(e => new
                            {
                                Value = Convert.ToInt32(e),
                                Text = e.GetDescription()
                            })
                            .ToList();

            return new SelectList(items, "Value", "Text");
        }
        public static SelectList GetEnumSelectListWithStatus<TEnum>() where TEnum : Enum
        {
            var items = Enum.GetValues(typeof(TEnum))
                            .Cast<TEnum>()
                            .Select(e => new
                            {
                                Value = Convert.ToInt32(e),
                                Text = SeparateString(e.GetDescription()).Item2
                            })
                            .ToList();

            return new SelectList(items, "Value", "Text");
        }
        public static Tuple<string, string> SeparateString(string input)
        {
            string[] parts = input.Split(':');
            if (parts.Length == 2)
            {
                return new Tuple<string, string>(parts[0], parts[1]);
            }
            else
            {
                throw new ArgumentException("Input string is not in the correct format.");
            }
        }

    }

    public static class EnumExtensions
    {
        public static string GetDescription<TEnum>(this TEnum value) where TEnum : Enum
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;

            return attribute?.Description ?? value.ToString();
        }
    }

}
