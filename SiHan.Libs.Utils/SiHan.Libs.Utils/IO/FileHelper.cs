using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;

namespace SiHan.Libs.Utils.IO
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// 采用UTF8编码读取文本文件的内容
        /// </summary>
        /// <param name="txtFile">文件路径</param>
        /// <returns>返回文件的文本内容</returns>
        public static string ReadTextFile(FileInfo txtFile)
        {
            string result = "";
            if (txtFile == null)
            {
                throw new ArgumentNullException(nameof(txtFile));
            }
            if (txtFile.Exists == false)
            {
                throw new FileNotFoundException("指定的文件不存在",txtFile.FullName);
            }
            else
            {
                using (StreamReader reader = new StreamReader(txtFile.FullName, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                return result;
            }
        }

        /// <summary>
        /// 采用UTF8编码覆盖或创建文本文件的内容
        /// </summary>
        /// <param name="txtFile">文本文件</param>
        /// <param name="text">文本内容</param>
        public static void WriteTextFile(FileInfo txtFile, string text)
        {
            if (txtFile == null)
            {
                throw new ArgumentNullException(nameof(txtFile));
            }
            string directoryPath = txtFile.DirectoryName;
            Directory.CreateDirectory(directoryPath);
            using (StreamWriter w = new StreamWriter(txtFile.FullName, false, Encoding.UTF8))
            {
                w.Write(text);
            }
        }
    }
}
