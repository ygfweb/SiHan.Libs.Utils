using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Seo
{
    /// <summary>
    /// 站点地图更新频率
    /// </summary>
    public enum SitemapFrequency
    {
        /// <summary>
        /// 从不
        /// </summary>
        Never,
        /// <summary>
        /// 每年
        /// </summary>
        Yearly,
        /// <summary>
        /// 每月
        /// </summary>
        Monthly,
        /// <summary>
        /// 每周
        /// </summary>
        Weekly,
        /// <summary>
        /// 每天
        /// </summary>
        Daily,
        /// <summary>
        /// 每小时
        /// </summary>
        Hourly,
        /// <summary>
        /// 总是
        /// </summary>
        Always
    }
}
