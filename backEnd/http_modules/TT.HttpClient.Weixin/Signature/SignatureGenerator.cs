using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Serilog;
using TT.HttpClient.Weixin.Models;

namespace TT.HttpClient.Weixin.Signature
{
    public class SignatureGenerator : ISignatureGenerator
    {
        public string Generate(PayParameters parameters, HashAlgorithm hashAlgorithm, string apiKey = null)
        {
            var signStr = $"{parameters.GetWaitForSignatureStr()}{(apiKey != null ? $"&key={apiKey}" : "")}";
            var signBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(signStr));
            Log.Information(signStr);

            var sb = new StringBuilder();
            foreach (var @byte in signBytes)
            {
                sb.Append($"{@byte:x2}");
            }

            return sb.ToString().ToUpper();
        }

        public string GetJsPaySign(string appId, string timeStamp, string nonceStr, string package, string key,
            string signType = "MD5")
        {
            //Hashtable pay = new Hashtable();
            // pay.Add("appId", appId);
            // pay.Add("timeStamp", timeStamp);
            // pay.Add("nonceStr", nonceStr);
            // pay.Add("package", package);
            // pay.Add("signType", signType);
            // return CreateMd5Sign(pay, "key", key);

            PayParameters pay = new PayParameters();
            pay.AddParameter("appId", appId);
            pay.AddParameter("timeStamp", timeStamp);
            pay.AddParameter("nonceStr", nonceStr);
            pay.AddParameter("package", package);
            pay.AddParameter("signType", signType);
            return Generate(pay, MD5.Create(), key);
        }

        /// <summary>
        /// 创建md5摘要,规则是:按参数名称a-z排序,遇到空值的参数不参加签名
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        /// key和value通常用于填充最后一组参数
        /// <returns></returns>
        public virtual string CreateMd5Sign(Hashtable ht, string key, string value)
        {
            StringBuilder sb = new StringBuilder();

            ArrayList akeys = new ArrayList(ht.Keys);
            akeys.Sort(ASCIISort.Create());

            foreach (string k in akeys)
            {
                string v = (string) ht[k];
                if (null != v && "".CompareTo(v) != 0
                              && "sign".CompareTo(k) != 0
                              //&& "sign_type".CompareTo(k) != 0
                              && "key".CompareTo(k) != 0)
                {
                    sb.Append(k + "=" + v + "&");
                }
            }

            sb.Append(key + "=" + value);

            //string sign = EncryptHelper.GetMD5(sb.ToString(), GetCharset()).ToUpper();

            //编码强制使用UTF8：https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=4_1
            string sign = GetMD5(sb.ToString(), "UTF-8").ToUpper();

            return sign;
        }

        /// <summary>获取大写的MD5签名结果</summary>
        /// <param name="encypStr">需要加密的字符串</param>
        /// <param name="charset">编码</param>
        /// <returns></returns>
        public static string GetMD5(string encypStr, string charset = "utf-8")
        {
            charset = charset ?? "utf-8";
            return GetMD5(encypStr, Encoding.GetEncoding(charset));
        }


        /// <summary>获取大写的MD5签名结果</summary>
        /// <param name="encypStr">需要加密的字符串</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        public static string GetMD5(string encypStr, Encoding encoding)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes;
            try
            {
                bytes = encoding.GetBytes(encypStr);
            }
            catch
            {
                bytes = Encoding.GetEncoding("utf-8").GetBytes(encypStr);
            }

            return BitConverter.ToString(md5.ComputeHash(bytes)).Replace("-", "").ToUpper();
        }
    }
}