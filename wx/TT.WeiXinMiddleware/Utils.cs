using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace TT.WeiXinMiddleware
{
    public static class Utils
    {
        /// <summary>
        /// <![CDATA[验证签名]]>
        /// </summary>
        /// <param name="nonce"></param>
        /// <param name="timestamp"></param>
        /// <param name="signature"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool CheckSignature(string nonce, string timestamp, string signature, string token)
        {
            if (nonce.IsNullOrEmptyOrWhiteSpace() ||
                timestamp.IsNullOrEmptyOrWhiteSpace() ||
                signature.IsNullOrEmptyOrWhiteSpace())
                return false;
            var strParameters = new string[] { token, timestamp, nonce };
            Array.Sort(strParameters);
            string strSignature = Sha1Encrypt(string.Join(string.Empty, strParameters));
            signature = signature.ToUpper();
            return (strSignature == signature);
        }

        #region sha1加密

        /// <summary>
        ///     进行sha1加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Sha1Encrypt(string input)
        {
            var pwBytes = Encoding.UTF8.GetBytes(input);
            var hash = SHA1.Create().ComputeHash(pwBytes);
            var hex = new StringBuilder();
            for (var i = 0; i < hash.Length; i++) hex.Append(hash[i].ToString("X2"));
            return hex.ToString();
        }
        #endregion sha1加密


        public static string ClearXmlHeader(string input)
        {
            return Regex.Replace(input, @"<\?xml([^>]+)\?>", string.Empty, RegexOptions.IgnoreCase);//过滤xml声明
        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string input)
        {
            return string.IsNullOrEmpty(input) && string.IsNullOrWhiteSpace(input);
        }
    }
}