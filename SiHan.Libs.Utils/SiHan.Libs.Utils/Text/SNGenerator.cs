using System;
using System.Collections.Generic;
using System.Text;

namespace SiHan.Libs.Utils.Text
{
    /// <summary>
    /// 序列号生成器
    /// </summary>
    public static class SNGenerator
    {
        // 省略了形状相识的字符, 例如 1,I; Q,O,0; 
        private static readonly char[] alphabet = "ABCDEFGHJKLMNPRSTUVWXYZ23456789".ToCharArray();
        private static readonly Random rand = new Random();
        /// <summary>
        /// 随机产生一个25位的序列号
        /// </summary>
        public static string GetNext()
        {
            return GetNext(25, '-', 5);
        }
        /// <summary>
        /// 产生一个新的序列号
        /// </summary>
        /// <param name="codeLength">序列号字符的总长度（不包含分隔符）</param>
        /// <param name="separatorChar">分隔符</param>
        /// <param name="segmentLength">每组字符的长度</param>
        /// <returns>返回新的序列号</returns>
        private static string GetNext(int codeLength, char separatorChar, int segmentLength)
        {
            char[] randChars = randomAlphabetChars(codeLength);
            char[] formattedChars = new char[codeLength + codeLength / segmentLength - 1];
            int numberOfSeparators = 0;
            for (int i = 0; i < randChars.Length; i++)
            {
                if (i % segmentLength == 0 && i != 0)
                    formattedChars[i + numberOfSeparators++] = separatorChar;
                formattedChars[i + numberOfSeparators] = randChars[i];
            }
            return new string(formattedChars);
        }
        private static char[] randomAlphabetChars(int length)
        {
            char[] newChars = new char[length];
            for (int i = 0; i < length; i++)
                newChars[i] = alphabet[(int)Math.Truncate(rand.NextDouble() * 1000) % alphabet.Length];
            return newChars;
        }
    }
}
