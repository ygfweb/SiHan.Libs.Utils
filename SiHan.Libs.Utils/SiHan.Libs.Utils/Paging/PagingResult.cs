using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Paging
{
    /// <summary>
    /// 分页结果
    /// </summary>
    public class PagingResult<T> where T : class
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 页总数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 分页尺寸
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 行总数
        /// </summary>
        public long RowCount { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// 分页结果构造函数
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="rowCount">行总数</param>
        /// <param name="data">数据集合</param>
        public PagingResult(int currentPage, int pageSize, long rowCount, List<T> data)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            RowCount = rowCount;
            this.Data = data;
            var pageCount = (double)rowCount / pageSize;
            this.PageCount = (int)Math.Ceiling(pageCount);
        }
    }
}
