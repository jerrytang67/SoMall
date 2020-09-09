using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TT.HttpClient.Weixin.Helpers
{
    public static class Encryption
    {
        /// <summary>
        ///     Aes解密
        /// </summary>
        /// <param name="encryptedDataStr">需要解密的字符串</param>
        /// <param name="key">密钥,长度不够时空格补齐,超过时从左截取</param>
        /// <param name="iv">偏移量,长度不够时空格补齐,超过时从左截取</param>
        /// <param name="keyLenth">秘钥长度,16 24 32</param>
        /// <param name="aesMode">解密模式</param>
        /// <param name="aesPadding">填充方式</param>
        /// <returns></returns>
        public static string AES_decrypt(string encryptedDataStr, string key, string iv, int keyLenth = 16,
            CipherMode aesMode = CipherMode.CBC, PaddingMode aesPadding = PaddingMode.PKCS7)
        {
            if (!new List<int> {16, 24, 32}.Contains(keyLenth))
                //密钥的长度，16位密钥 = 128位，24位密钥 = 192位，32位密钥 = 256位。
                return null;

            var oldBytes = Convert.FromBase64String(encryptedDataStr);
            var bKey = new byte[keyLenth];
            Array.Copy(Convert.FromBase64String(key.PadRight(keyLenth)), bKey, keyLenth);
            var bIv = new byte[16];
            Array.Copy(Convert.FromBase64String(iv.PadRight(16)), bIv, 16);

            var rijalg = new RijndaelManaged
            {
                Mode = aesMode,
                Padding = aesPadding,
                Key = bKey,
                IV = bIv
            };
            var decryptor = rijalg.CreateDecryptor(rijalg.Key, rijalg.IV);
            var rtByte = decryptor.TransformFinalBlock(oldBytes, 0, oldBytes.Length);
            return Encoding.UTF8.GetString(rtByte);
        }
    }
}