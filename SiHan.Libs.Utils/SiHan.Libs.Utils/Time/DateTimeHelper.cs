using System;
using System.Collections.Generic;
using System.Text;
using SiHan.Libs.Utils.Text;

namespace SiHan.Libs.Utils.Time
{
    /// <summary>
    /// 日期帮助类
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// 获取当月的所有日期
        /// </summary>
        public static List<DateTime> GetCurrentMonthDateTimes()
        {
            DateTime now = DateTime.Now;
            int day = now.Day;
            List<DateTime> dateTimes = new List<DateTime>();
            for (int i = 1; i <= day; i++)
            {
                DateTime dt = new DateTime(now.Year, now.Month, i, 0, 0, 0);
                dateTimes.Add(dt);
            }

            return dateTimes;
        }

        /// <summary>
        /// 获取指定日期的零时
        /// </summary>
        public static DateTime GetStartDateTime(DateTime dt)
        {
            if (dt == null)
            {
                throw new ArgumentNullException(nameof(dt));
            }

            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }

        /// <summary>
        /// 获取指定日期的23时59分
        /// </summary>
        public static DateTime GetEndDateTime(DateTime dt)
        {
            if (dt == null)
            {
                throw new ArgumentNullException(nameof(dt));
            }

            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
        }

        /// <summary>
        /// 获取指定日期的0时和23时59分
        /// </summary>
        public static Tuple<DateTime, DateTime> GetStartEndDatetime(DateTime dt)
        {
            if (dt == null)
            {
                throw new ArgumentNullException(nameof(dt));
            }
            DateTime start = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
            DateTime end = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            Tuple<DateTime, DateTime> tuple = new Tuple<DateTime, DateTime>(start, end);
            return tuple;
        }

        /// <summary>
        /// 将两个日期转换成起始日期和截止日期，便于时间段统计
        /// </summary>
        public static Tuple<DateTime, DateTime> GetStartEndDatetime(DateTime dt1, DateTime dt2)
        {
            if (dt1 == null)
            {
                throw new ArgumentNullException(nameof(dt1));
            }
            if (dt2 == null)
            {
                throw new ArgumentNullException(nameof(dt2));
            }
            DateTime start, end;
            if (dt2 >= dt1)
            {
                start = dt1;
                end = dt2;
            }
            else
            {
                start = dt2;
                end = dt1;
            }

            start = GetStartDateTime(start);
            end = GetEndDateTime(end);
            Tuple<DateTime, DateTime> tuple = new Tuple<DateTime, DateTime>(start, end);
            return tuple;
        }

        /// <summary>
        /// 获取月份日期列表（含指定日期与之前的当月日期）
        /// </summary>
        public static List<DateTime> GetMonthDayList(DateTime dt)
        {
            if (dt == null)
            {
                throw new ArgumentNullException(nameof(dt));
            }

            int day = dt.Day;
            List<DateTime> dateTimes = new List<DateTime>();
            for (int i = 1; i <= day; i++)
            {
                DateTime dateTime = new DateTime(dt.Year, dt.Month, 1, 0, 0, 0);
                dateTimes.Add(dateTime);
            }

            return dateTimes;
        }

        /// <summary>
        /// 获取最近天数的日期
        /// </summary>
        public static List<DateTime> GetRecentDate(DateTime time, int days = 10)
        {
            if (days < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(days), "参数必须大于1");
            }

            List<DateTime> dateTimes = new List<DateTime>();
            for (int i = 0; i < days; i++)
            {
                dateTimes.Add(time.AddDays(-i));
            }

            return dateTimes;
        }

        /// <summary>
        /// 获取最近天数的日期
        /// </summary>
        public static List<DateTime> GetRecentDate(int days = 10)
        {
            return GetRecentDate(DateTime.Now, days);
        }


        /// <summary>
        /// 获取两个时间之间的所有日期
        /// </summary>
        public static List<DateTime> GetList(DateTime startTime, DateTime endTime)
        {
            List<DateTime> dateTimes = new List<DateTime>();
            for (DateTime dt = startTime; dt <= endTime; dt = dt.AddDays(1))
            {
                dateTimes.Add(dt);
            }

            return dateTimes;
        }

        /// <summary>
        /// 格式化显示时间为几个月,几天前,几小时前,几分钟前,或几秒前
        /// </summary>
        public static string DateStringFromNow(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalDays > 60)
            {
                return FormatHelper.ToTime(dt);
            }
            else if (span.TotalDays > 30)
            {
                return "1个月前";
            }
            else if (span.TotalDays > 14)
            {
                return "2周前";
            }
            else if (span.TotalDays > 7)
            {
                return "1周前";
            }
            else if (span.TotalDays > 1)
            {
                return string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
            }
            else if (span.TotalHours > 1)
            {
                return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
            }
            else if (span.TotalMinutes > 1)
            {
                return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
            }
            else if (span.TotalSeconds >= 1)
            {
                return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
            }
            else
            {
                return "1秒前";
            }
        }
    }
}
