using System;
/*************************************************
 * 代码来源：https://stackoverflow.com/a/3862106
 *************************************************/

using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// UTF8字符串编写器
    /// </summary>
    public class Utf8StringWriter : StringWriter
    {
        /// <summary>
        /// 将原UTF16修改为UTF8编码
        /// </summary>
        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}
