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
