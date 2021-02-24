using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// 格式化帮助类
    /// </summary>
    public static class FormatHelper
    {
        /// <summary>
        /// 格式化时间为长格式（yyyy-MM-dd HH:mm:ss）
        /// </summary>
        public static string ToTime(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return "";
            }
            else
            {
                return dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 格式化时间为短格式（yyyy-MM-dd）
        /// </summary>
        public static string ToDate(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return "";
            }
            else
            {
                return dateTime.Value.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 格式化时间为中文日期格式（yyyy年MM月dd日）
        /// </summary>
        public static string ToChinaDate(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return "";
            }
            else
            {
                return dateTime.Value.ToString("yyyy年MM月dd日");
            }
        }

        /// <summary>
        /// 格式化为中文时间（yyyy年MM月dd日HH时mm分ss秒）
        /// </summary>
        public static string ToChinaTime(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return "";
            }
            else
            {
                return dateTime.Value.ToString("yyyy年MM月dd日HH时mm分ss秒");
            }
        }

        /// <summary>
        /// 格式化为中文星期
        /// </summary>
        public static string ToChinaWeek(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return "";
            }
            else
            {
                string[] days = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                return days[Convert.ToInt16(DateTime.Now.DayOfWeek)];
            }
        }

        /// <summary>
        /// 将bool值转换为汉字是与否
        /// </summary>
        public static string ToBoolean(bool? bz)
        {
            if (bz.HasValue)
            {
                if (bz.Value)
                {
                    return "是";
                }
                else
                {
                    return "否";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 格式化为货币字符串
        /// </summary>
        public static string ToMoney(decimal money, string currencySymbol = "￥", int pointNumber = 2)
        {
            decimal value = Math.Round(money, pointNumber);
            return currencySymbol + value;
        }

        /// <summary>
        /// 数字格式化为多少K
        /// </summary>
        public static string FormatNumber(long num)
        {
            if (num >= 100000000)
            {
                return (num / 1000000D).ToString("0.#M");
            }
            if (num >= 1000000)
            {
                return (num / 1000000D).ToString("0.#M");
            }
            if (num >= 100000)
            {
                return (num / 1000D).ToString("0.#k");
            }
            if (num >= 10000)
            {
                return (num / 1000D).ToString("0.#k");
            }

            return num.ToString("#,0");
        }
    }
}
