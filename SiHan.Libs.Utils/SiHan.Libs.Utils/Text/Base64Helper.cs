using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// BASE64助手类
    /// </summary>
    public static class Base64Helper
    {
        /// <summary>
        /// 编码
        /// </summary>
        public static string Encode(string sourceText)
        {
            if (string.IsNullOrWhiteSpace(sourceText))
            {
                return "";
            }
            else
            {
                byte[] bytes = Encoding.UTF8.GetBytes(sourceText);
                return Convert.ToBase64String(bytes, Base64FormattingOptions.None);
            }
        }

        /// <summary>
        /// 解码
        /// </summary>
        public static string Decode(string base64Text)
        {
            if (string.IsNullOrWhiteSpace(base64Text))
            {
                return "";
            }
            else
            {
                byte[] bytes = Convert.FromBase64String(base64Text);
                return Encoding.UTF8.GetString(bytes);
            }
        }
        /// <summary>
        /// byte数组转换成base64字符串
        /// </summary>
        public static string ToBase64String(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return "";
            }
            else
            {
                return Convert.ToBase64String(bytes, Base64FormattingOptions.None);
            }
        }

        /// <summary>
        /// base64字符串转换成byte数组
        /// </summary>
        public static byte[] FromBase64String(string base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
            {
                return Array.Empty<byte>();
            }
            else
            {
                return Convert.FromBase64String(base64);
            }
        }
    }
}
