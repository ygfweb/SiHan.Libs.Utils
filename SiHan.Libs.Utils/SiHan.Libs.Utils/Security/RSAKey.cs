using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Security
{
    /// <summary>
    /// RSA密钥
    /// </summary>
    public class RSAKey
    {
        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; internal set; }
        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; internal set; }
    }
}

