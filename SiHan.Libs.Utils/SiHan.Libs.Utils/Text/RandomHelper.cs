using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// 随机数生成器
    /// </summary>
    public static class RandomHelper
    {
        /// <summary>
        /// 获得随机整数
        /// </summary>
        public static int GetIntNumber(int min, int max)
        {
            var r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(min, max);
        }
        /// <summary>
        /// 获取随机字符串（默认是英语字母）
        /// </summary>
        public static string GetLetters(int length = 5, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            if (length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            if (string.IsNullOrWhiteSpace(allowedChars))
            {
                throw new ArgumentNullException(nameof(allowedChars));
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int num = GetIntNumber(0, allowedChars.Length);
                sb.Append(allowedChars[num]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取随机验证码字符串
        /// </summary>
        public static string GetVerifyCode()
        {
            return GetLetters(5, "ABCDEFGHJKMNPQRSTUVWXYZ23456789");
        }

        /// <summary>
        /// 获取20位的随机单号（时间+随机数）
        /// </summary>
        public static string GetOrderNo()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff") + GetIntNumber(100, 999);
        }
    }
}
