using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SiHan.Libs.Utils.Security
{
    /// <summary>
    /// RSA帮助类
    /// </summary>
    public class RSAHelper
    {
        /// <summary>
        /// 采用RSA非对称算法对文本进行签名
        /// </summary>
        /// <param name="privateKeyXml">私钥的XML文本</param>
        /// <param name="text">需要签名的文本内容（即文件体）</param>
        /// <returns>返回签名后的base64编码密文（即文件头）</returns>
        public static string PrivateKeyTextSignatureData(string privateKeyXml, string text)
        {
            string hashText = Md5Encryptor.Hash(text);
            byte[] hashBytes = Convert.FromBase64String(hashText);
            RSACryptoServiceProvider p = new RSACryptoServiceProvider();
            p.FromXmlString(privateKeyXml);
            RSAPKCS1SignatureFormatter f = new RSAPKCS1SignatureFormatter(p);
            f.SetHashAlgorithm("SHA");
            byte[] bytes = f.CreateSignature(hashBytes);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 采用RSA非对称算法对文本进行签名验证
        /// </summary>
        /// <param name="publicKeyXml">公钥的XML文本</param>
        /// <param name="text">需要验证签名的文本内容（即文件体）</param>
        /// <param name="signatureBase64Text">已签名的base64密文（即文件头）</param>
        /// <returns>如果文件内容与文件头匹配，则返回true，否则返回false</returns>
        public static bool PublicKeyTextValidateData(string publicKeyXml, string text, string signatureBase64Text)
        {
            RSACryptoServiceProvider p = new RSACryptoServiceProvider();
            p.FromXmlString(publicKeyXml);
            RSAPKCS1SignatureDeformatter f = new RSAPKCS1SignatureDeformatter(p);
            f.SetHashAlgorithm("SHA");
            byte[] bytes = Convert.FromBase64String(Md5Encryptor.Hash(text));
            byte[] bytes2 = Convert.FromBase64String(signatureBase64Text);
            if (f.VerifySignature(bytes, bytes2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 创建新的密钥
        /// </summary>
        public static RSAKey CreateKey()
        {
            using (RSA rsa= RSA.Create())
            {
                return new RSAKey
                {
                    PrivateKey = rsa.ToXmlString(true),
                    PublicKey = rsa.ToXmlString(false)
                };
            }
        }
    }
}
