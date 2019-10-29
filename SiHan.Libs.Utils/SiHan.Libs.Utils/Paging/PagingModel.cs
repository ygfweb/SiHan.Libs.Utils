using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Paging
{
    /// <summary>
    /// 分页模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingModel<T> where T : class
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int Page { get; set; } = 1;
        /// <summary>
        /// 行总数
        /// </summary>
        public long RowCount { get; set; } = 0;
        /// <summary>
        /// 当前页数据
        /// </summary>
        public List<T> Data = new List<T>();
    }
}
