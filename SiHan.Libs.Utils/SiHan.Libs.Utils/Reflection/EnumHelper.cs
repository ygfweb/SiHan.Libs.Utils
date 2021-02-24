using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        /// <summary>
        /// 将枚举类转换成字典
        /// </summary>
        public static Dictionary<T, string> ToDictionary()
        {
            Dictionary<T, string> result = new Dictionary<T, string>();
            Type enumType = typeof(T);
            foreach (T item in Enum.GetValues(enumType))
            {
                string text = GetDescription(item);
                result.Add(item, text);
            }
            return result;
        }

        /// <summary>
        /// 获取枚举的最大值
        /// </summary>
        public static int GetMaxValue()
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Max();
        }

        /// <summary>
        /// 获取枚举的最小值
        /// </summary>
        public static int GetMinValue()
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Min();
        }
    }
}
