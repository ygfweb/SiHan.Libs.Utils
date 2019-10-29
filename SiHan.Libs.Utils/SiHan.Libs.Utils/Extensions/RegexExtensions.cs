using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SiHan.Libs.Utils.Extensions
{
    /// <summary>
    /// 正则表达式扩展
    /// </summary>
    public static class RegexExtensions
    {
        /// <summary>
        /// 获取匹配文本，匹配失败返回空字符串
        /// </summary>
        public static string GetMatchString(this Regex regex, string text)
        {
            var match = regex.Match(text);
            return match.Success ? match.Value : string.Empty;
        }
    }
}
