using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// 排序帮助类
    /// </summary>
    public class SortHelper
    {
        private const string DescName = "DESC";
        private const string AscName = "ASC";

        /// <summary>
        /// 生成降序字符串
        /// </summary>
        /// <returns></returns>
        public static string GenerateDescText(string fieldName)
        {
            return fieldName + "_" + DescName;
        }
        /// <summary>
        /// 生成升序字符串
        /// </summary>
        public static string GenerateAscText(string fieldName)
        {
            return fieldName + "_" + AscName;
        }

        /// <summary>
        /// 检查字段是否是降序排序
        /// </summary>
        public static bool IsDescSort(string fieldName, string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(sortOrder))
            {
                return false;
            }
            else
            {
                if (sortOrder.ToLower() == GenerateDescText(fieldName).ToLower())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 检查字段是否是升序排序
        /// </summary>
        public static bool IsAscSort(string fieldName, string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(sortOrder))
            {
                return false;
            }
            else
            {
                if (sortOrder.ToLower() == GenerateAscText(fieldName).ToLower())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 检查排序是否是按该字段排序
        /// </summary>
        public static bool IsSort(string fieldName, string sortOrder)
        {
            if (IsDescSort(fieldName, sortOrder) || IsAscSort(fieldName, sortOrder))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 反转排序方向
        /// </summary>
        public static string ReverseSort(string fieldName, string sortOrder)
        {
            if (IsDescSort(fieldName, sortOrder))
            {
                return GenerateAscText(fieldName);
            }
            else
            {
                return GenerateDescText(fieldName);
            }
        }
    }
}
