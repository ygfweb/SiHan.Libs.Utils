using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// GUID帮助类
    /// </summary>
    public static class GuidHelper
    {
        /// <summary>
        /// 生成带序列的guid字符串
        /// </summary>
        public static string CreateSequentialString()
        {
            return SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAsString).ToString();
        }
    }
}
