﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECAF.INFRASTRUCTURE.utils
{
   public class Helpers
    {
        public static string GetEnumDescription<T>(string value)
        {
            Type type = typeof(T);
            var name = Enum.GetNames(type).Where(f => f.Equals(value,
                StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();
            if (name == null)
            {
                return string.Empty;
            }
            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ?
                   ((DescriptionAttribute)customAttribute[0]).Description : name;
        }
    }
}
