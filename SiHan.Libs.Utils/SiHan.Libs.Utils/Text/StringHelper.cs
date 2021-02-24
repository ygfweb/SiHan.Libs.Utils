using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 通过分隔符将字符串转换成List
        /// </summary>
        /// <param name="text"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static List<string> ToList(string text, string separator = ",")
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new List<string>();
            }
            else
            {
                string[] array = new string[] { separator };
                return text.Split(array, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        /// <summary>
        /// 将List连接成一个字符串
        /// </summary>
        public static string FromList(List<string> list, string separator = ",")
        {
            if (list == null)
            {
                return "";
            }
            else
            {
                return string.Join(separator, list.ToArray());
            }
        }

        /// <summary>
        /// 任意字符串转全角
        /// </summary>
        public static string ToFullWidth(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }
            else
            {
                // 半角转全角：
                char[] c = input.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == 32)
                    {
                        c[i] = (char)12288;
                        continue;
                    }
                    if (c[i] < 127)
                        c[i] = (char)(c[i] + 65248);
                }
                return new String(c);
            }
        }
        /// <summary>
        /// 任意字符串转半角
        /// </summary>
        public static string ToHalfWidth(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }
            else
            {
                char[] c = input.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (c[i] == 12288)
                    {
                        c[i] = (char)32;
                        continue;
                    }
                    if (c[i] > 65280 && c[i] < 65375)
                        c[i] = (char)(c[i] - 65248);
                }
                return new string(c);
            }
        }

        /// <summary>
        /// 判断字符串是否相等（默认忽略大小写）
        /// </summary>
        public static bool IsEqual(string text1, string text2, bool ignoreCase = true)
        {
            if (ignoreCase)
            {
                return string.Equals(text1, text2, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                return string.Equals(text1, text2);
            }
        }

        /// <summary>
        /// 判断任意对象是否为空或空白
        /// </summary>
        public static bool IsNullOrEmpty(object data)
        {
            if (data == null)
            {
                return true;
            }
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrWhiteSpace(data.ToString()))
                {
                    return true;
                }
            }
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取GUID字符串，去掉横线，全部小写
        /// </summary>
        public static string GetGuidString()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToLower();
        }

        /// <summary>
        /// 移除文本中的换行符
        /// </summary>
        public static string RemoveNewLine(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }
            else
            {
                return text.Replace(Environment.NewLine, " ");
            }
        }

        /// <summary>
        /// 将一个字符串转换为bool值，支持中文（是、否）、数字（1、0）、英文（true、false、yes、no、t、f）
        /// </summary>
        /// <param name="text">待转换的字符串</param>
        /// <param name="defaultVal">转换失败的默认值</param>
        /// <returns></returns>
        public static bool ParseToBoolean(string text, bool defaultVal)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return defaultVal;
            }
            else if (text == "是")
            {
                return true;
            }
            else if (text == "否")
            {
                return false;
            }
            else if (text == "1")
            {
                return true;
            }
            else if (text == "0")
            {
                return false;
            }
            else if (text.ToLower() == "yes")
            {
                return true;
            }
            else if (text.ToLower() == "no")
            {
                return false;
            }
            else if (text.ToLower() == "t")
            {
                return true;
            }
            else if (text.ToLower() == "f")
            {
                return false;
            }
            else
            {
                try
                {
                    return Convert.ToBoolean(defaultVal);
                }
                catch
                {
                    return defaultVal;
                }
            }
        }

        /// <summary>
        /// 将一个字符串（前面可带货币符号）转换成整数值，如果是空字符串则结果为0，如果转换失败则为默认值
        /// </summary>
        /// <param name="text">任意字符串</param>
        /// <param name="defaultValue">转换失败的默认值</param>
        /// <returns></returns>
        public static int ParseToInt(string text, int defaultValue)
        {
            text = RemoveCurrencySign(text);
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }
            else
            {
                try
                {
                    return Convert.ToInt32(text);
                }
                catch
                {
                    return defaultValue;
                }
            }
        }
        /// <summary>
        /// 将一个字符串（前面可带货币符号）转换成浮点值，如果是空字符串则结果为0，如果转换失败则为默认值
        /// </summary>
        /// <param name="text">任意字符串</param>
        /// <param name="defaultValue">转换失败的默认值</param>
        /// <returns></returns>
        public static decimal ParseToDecimal(string text, decimal defaultValue)
        {
            text = RemoveCurrencySign(text);
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }
            else
            {
                try
                {
                    return Convert.ToDecimal(text);
                }
                catch
                {
                    return defaultValue;
                }
            }
        }

        /// <summary>
        /// 移除字符串开头的货币符号（￥、$）
        /// </summary>
        public static string RemoveCurrencySign(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }
            text = text.Trim();
            if (text.StartsWith("$"))
            {
                return text.TrimStart('$').Trim();
            }
            if (text.StartsWith("￥"))
            {
                return text.TrimStart('￥').Trim();
            }
            return text;
        }

        /// <summary>
        /// 将指定字符串按指定长度进行截取并加上指定的后缀
        /// </summary>
        public static string StringTruncat(string oldStr, int maxLength, string endWith = "...")
        {
            //判断原字符串是否为空
            if (string.IsNullOrEmpty(oldStr))
                return oldStr + endWith;

            //返回字符串的长度必须大于1
            if (maxLength < 1)
                throw new Exception("返回的字符串长度必须大于[0] ");

            //判断原字符串是否大于最大长度
            if (oldStr.Length > maxLength)
            {
                //截取原字符串
                string strTmp = oldStr.Substring(0, maxLength);
                //判断后缀是否为空
                if (string.IsNullOrEmpty(endWith))
                    return strTmp;
                else
                    return strTmp + endWith;
            }
            return oldStr;
        }

        /// <summary>
        /// Pascal风格转小写下划线
        /// </summary>
        public static string PascalCaseToUnderscores(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }
            else
            {
                input = input.Trim();
                string result = "";  //目标字符串
                for (int j = 0; j < input.Length; j++)
                {
                    string temp = input[j].ToString();
                    if (Regex.IsMatch(temp, "[A-Z]"))
                    {
                        temp = "_" + temp.ToLower();
                    }
                    result = result + temp;
                }
                return result.Trim('_');
            }
        }
    }
}
