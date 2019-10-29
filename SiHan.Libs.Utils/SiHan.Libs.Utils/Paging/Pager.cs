/*
 * 代码来源：http://jasonwatmore.com/post/2018/10/17/c-pure-pagination-logic-in-c-aspnet
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiHan.Libs.Utils.Paging
{
    /// <summary>
    /// 分页类
    /// </summary>
    public class Pager
    {
        /// <summary>
        ///  数据行总数
        /// </summary>
        public long RowCount { get; private set; }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// 分页尺寸
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// 分页总数
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// 起始页码
        /// </summary>
        public int StartPage { get; private set; }

        /// <summary>
        /// 截至页码
        /// </summary>
        public int EndPage { get; private set; }

        /// <summary>
        /// 上一页码
        /// </summary>
        public int PreviousPage
        {
            get { return CurrentPage - 1; }
        }

        /// <summary>
        /// 下一页页码
        /// </summary>
        public int NextPage
        {
            get { return CurrentPage + 1; }
        }

        /// <summary>
        /// 分页页码
        /// </summary>
        public List<int> Pages { get; private set; }

        /// <summary>
        /// 具有上一页
        /// </summary>
        public bool HasPreviousPage
        {
            get { return CurrentPage > 1; }
        }

        /// <summary>
        /// 具有下一页
        /// </summary>
        public bool HasNextPage
        {
            get { return CurrentPage < TotalPages; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="maxPages"></param>
        public Pager(long rowCount, int currentPage = 1, int pageSize = 10, int maxPages = 5)
        {
            // calculate total pages
            var totalPages = (int)Math.Ceiling((decimal)rowCount / (decimal)pageSize);

            // ensure current page isn't out of range
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            else if (currentPage > totalPages)
            {
                currentPage = totalPages;
            }

            int startPage, endPage;
            if (totalPages <= maxPages)
            {
                // total pages less than max so show all pages
                startPage = 1;
                endPage = totalPages;
            }
            else
            {
                // total pages more than max so calculate start and end pages
                var maxPagesBeforeCurrentPage = (int)Math.Floor((decimal)maxPages / (decimal)2);
                var maxPagesAfterCurrentPage = (int)Math.Ceiling((decimal)maxPages / (decimal)2) - 1;
                if (currentPage <= maxPagesBeforeCurrentPage)
                {
                    // current page near the start
                    startPage = 1;
                    endPage = maxPages;
                }
                else if (currentPage + maxPagesAfterCurrentPage >= totalPages)
                {
                    // current page near the end
                    startPage = totalPages - maxPages + 1;
                    endPage = totalPages;
                }
                else
                {
                    // current page somewhere in the middle
                    startPage = currentPage - maxPagesBeforeCurrentPage;
                    endPage = currentPage + maxPagesAfterCurrentPage;
                }
            }

            // calculate start and end item indexes
            var startIndex = (currentPage - 1) * pageSize;
            var endIndex = Math.Min(startIndex + pageSize - 1, rowCount - 1);

            // create an array of pages that can be looped over
            var pages = Enumerable.Range(startPage, (endPage + 1) - startPage);

            // update object instance with all pager properties required by the view
            RowCount = rowCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            Pages = pages.ToList();
        }
    }
}
