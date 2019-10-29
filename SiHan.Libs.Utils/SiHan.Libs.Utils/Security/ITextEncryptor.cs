using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Security
{
    /// <summary>
    /// 文本加密接口
    /// </summary>
    public interface ITextEncryptor
    {
        /// <summary>
        /// 加密字符串
        /// </summary>
        string Encrypt(string sourceText);

        /// <summary>
        /// 解密字符串
        /// </summary>
        string Decrypt(string encryptBase64);
    }
}
