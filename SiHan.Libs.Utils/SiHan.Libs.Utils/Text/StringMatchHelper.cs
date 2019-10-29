
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// 字符串匹配帮助类
    /// </summary>
    public static class StringMatchHelper
    {

        /// <summary>
        /// 判断字符串是否为字母或数字
        /// </summary>
        public static bool IsLetterOrInteger(string t)
        {
            return Regex.IsMatch(t, @"^[A-Za-z0-9]+$");
        }

        /// <summary>
        /// 判断字符串是否为大小写字母
        /// </summary>
        public static bool IsLetter(string t)
        {
            return Regex.IsMatch(t, @"^[A-Za-z]+$");
        }

        /// <summary>
        /// 判断字符串是否为数字
        /// </summary>
        public static bool IsInteger(string t)
        {
            return Regex.IsMatch(t, @"^[0-9]+$");
        }

        /// <summary>
        /// 判断字符串是否为email
        /// </summary>
        public static bool IsEmail(string t)
        {
            return Regex.IsMatch(t, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        /// <summary>
        /// 验证身份证
        /// </summary>
        public static bool IsIDCard(string t)
        {
            return Regex.IsMatch(t, @"\d{15}") || Regex.IsMatch(t, @"^\d{18}$") || Regex.IsMatch(t, @"^\d{17}(\d|X|x)$");
        }

        /// <summary>
        /// 验证是否是中文字符
        /// </summary>
        public static bool IsChinese(string t)
        {
            return Regex.IsMatch(t, @"^[\u4e00-\u9fa5]+$");
        }

        /// <summary>
        /// 验证是否是IP地址
        /// </summary>
        public static bool IsIp(string t)
        {
            return Regex.IsMatch(t, @"^\d+\.\d+\.\d+\.\d+$");
        }
        /// <summary>
        /// 验证手机号
        /// </summary>
        public static bool IsPhone(string t)
        {
            return Regex.IsMatch(t, @"^1[3-9]\d{9}$");
        }
    }
}




