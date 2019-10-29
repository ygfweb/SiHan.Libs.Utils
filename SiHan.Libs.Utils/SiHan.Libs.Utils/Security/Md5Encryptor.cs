using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SiHan.Libs.Utils.Security
{
    /// <summary>
    /// MD5加密器
    /// </summary>
    public static class Md5Encryptor
    {
        private static readonly string _key = "@ab+&?###";

        /// <summary>
        /// 加盐的MD5
        /// </summary>
        public static string Hash(string text)
        {
            text = text + _key;
            using (var md5 = MD5.Create())
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                //var result = Encoding.UTF8.GetString(bytes);
                var result = BitConverter.ToString(bytes);
                return result.Replace("-", "").ToLower();
            }
        }
    }
}
