using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SiHan.Libs.Utils.Security
{
    /// <summary>
    /// AES对称加密器
    /// </summary>
    public class AesEncryptor
    {
        private string Key = "gJDOxm0oyquVxuLy";
        private string Iv = "0123456789123456";

        /// <summary>
        /// 使用默认密钥创建加密器
        /// </summary>
        public AesEncryptor()
        {
        }

        /// <summary>
        /// 使用指定密钥创建加密器
        /// </summary>
        public AesEncryptor(string key, string iv)
        {
            Key = key;
            Iv = iv;
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        public string Encrypt(string sourceText)
        {
            using (AesCryptoServiceProvider provider = new AesCryptoServiceProvider())
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(Key);
                byte[] ivBytes = Encoding.UTF8.GetBytes(Iv);
                provider.Key = keyBytes;
                provider.IV = ivBytes;
                byte[] encrypted;
                ICryptoTransform encryptor = provider.CreateEncryptor(provider.Key, provider.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt, Encoding.UTF8))
                        {
                            swEncrypt.Write(sourceText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
                return Convert.ToBase64String(encrypted);
            }
        }
        /// <summary>
        /// 解密字符串
        /// </summary>
        public string Decrypt(string encryptBase64)
        {
            string oldText = "";
            try
            {
                byte[] src = Convert.FromBase64String(encryptBase64);
                using (AesCryptoServiceProvider provider = new AesCryptoServiceProvider())
                {
                    byte[] keyBytes = Encoding.UTF8.GetBytes(Key);
                    byte[] ivBytes = Encoding.UTF8.GetBytes(Iv);
                    provider.Key = keyBytes;
                    provider.IV = ivBytes;
                    ICryptoTransform decryptor = provider.CreateDecryptor(provider.Key, provider.IV);
                    using (MemoryStream msDecrypt = new MemoryStream(src))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt, Encoding.UTF8))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                oldText = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {
                oldText = "";
            }

            return oldText;
        }

        /// <summary>
        /// 加密字符串（使用默认秘钥）
        /// </summary>
        public static string EncryptWithDefaultKey(string sourceText)
        {
            AesEncryptor encrypt = new AesEncryptor();
            return encrypt.Encrypt(sourceText);
        }

        /// <summary>
        /// 解密字符串（使用默认秘钥）
        /// </summary>
        /// <param name="encryptBase64"></param>
        /// <returns></returns>
        public static string DecryptWithDefaultKey(string encryptBase64)
        {
            AesEncryptor encrypt = new AesEncryptor();
            return encrypt.Decrypt(encryptBase64);
        }
    }
}
