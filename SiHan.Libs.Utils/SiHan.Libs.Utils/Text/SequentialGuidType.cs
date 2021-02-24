using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// 序列GUID类型
    /// </summary>
    public enum SequentialGuidType
    {
        /// <summary>
        /// MySQL char(36)、PostgreSQL uuid 
        /// </summary>
        SequentialAsString,
        /// <summary>
        /// Oracle 	raw(16) 
        /// </summary>
        SequentialAsBinary,
        /// <summary>
        /// Microsoft SQL Server uniqueidentifier 
        /// </summary>
        SequentialAtEnd
    }
}
