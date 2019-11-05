using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace SiHan.Libs.Utils.Reflection
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumHelper<T> where T : Enum
    {
        /// <summary>
        /// 获取当前枚举值的描述
        /// </summary>
        public static string GetDescription(T value)
        {
            if (value == null)
            {
                return "";
            }
            else
            {
                var type = value.GetType();
                var fieldInfo = type.GetField(value.ToString());
                var attr = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
                if (attr != null)
                {
                    return attr.Description; ;
                }
                else
                {
                    return "";
                }
            }
        }

    }
}
