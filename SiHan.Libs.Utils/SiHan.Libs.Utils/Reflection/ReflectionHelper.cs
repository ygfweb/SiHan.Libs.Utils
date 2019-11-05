using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SiHan.Libs.Utils.Reflection
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// 获取所有公开属性（默认包含继承的属性）
        /// </summary>
        /// <param name="isIncludeExtend">是否包含继承的属性</param>
        /// <returns></returns>
        public static List<PropertyInfo> GetPublicPropertys<T>(bool isIncludeExtend = true) where T : class
        {
            if (isIncludeExtend)
            {
                PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                return properties.ToList();
            }
            else
            {
                PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                return properties.ToList();
            }
        }

        /// <summary>
        /// 获取类的自定义特性
        /// </summary>
        public static S GetClassAttribute<T, S>() where T : class where S : Attribute
        {
            Type type = typeof(T);
            return type.GetCustomAttribute<S>();
        }
    }
}



