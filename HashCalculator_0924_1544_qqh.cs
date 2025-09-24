// 代码生成时间: 2025-09-24 15:44:36
 * 作者：[你的名字]
 * 日期：[当前日期]
 */

using System;
using System.Security.Cryptography;
using System.Text;

namespace HashCalculatorApp
{
    /// <summary>
    /// 哈希值计算工具类
    /// </summary>
    public class HashCalculator
    {
        /// <summary>
        /// 计算MD5哈希值
        /// </summary>
        /// <param name="input">待计算哈希的原始字符串</param>
        /// <returns>MD5哈希值的十六进制字符串</returns>
        public string CalculateMD5Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("输入不能为空", nameof(input));
            }

            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// 计算SHA1哈希值
        /// </summary>
        /// <param name="input">待计算哈希的原始字符串</param>
        /// <returns>SHA1哈希值的十六进制字符串</returns>
        public string CalculateSHA1Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("输入不能为空", nameof(input));
            }

            using (var sha1 = SHA1.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha1.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// 计算SHA256哈希值
        /// </summary>
        /// <param name="input">待计算哈希的原始字符串</param>
        /// <returns>SHA256哈希值的十六进制字符串</returns>
        public string CalculateSHA256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("输入不能为空", nameof(input));
            }

            using (var sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        // 可以按照需要添加更多哈希算法的计算方法
    }
}
