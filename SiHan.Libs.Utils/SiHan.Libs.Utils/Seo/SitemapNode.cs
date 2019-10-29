using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Seo
{
    /// <summary>
    /// 站点地图节点
    /// </summary>
    public class SitemapNode
    {
        /// <summary>
        /// 更新频率
        /// </summary>
        public SitemapFrequency? Frequency { get; set; }
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime? LastModified { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public double? Priority { get; set; }
        /// <summary>
        /// URL网址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 站点地图节点
        /// </summary>
        public SitemapNode(string url, DateTime? lastModified = null, double? priority = null, SitemapFrequency? frequency = null)
        {
            Frequency = frequency;
            LastModified = lastModified;
            Priority = priority;
            Url = url;
        }
    }
}
