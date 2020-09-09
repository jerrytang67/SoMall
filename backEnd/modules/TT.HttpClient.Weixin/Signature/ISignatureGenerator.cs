using System.Security.Cryptography;
using TT.HttpClient.Weixin.Models;

namespace TT.HttpClient.Weixin.Signature
{
    public interface ISignatureGenerator
    {
        /// <summary>
        ///     根据传入的参数字典，生成签名数据。
        /// </summary>
        /// <returns>生成的签名数据。</returns>
        string Generate(PayParameters payRequest, HashAlgorithm hashAlgorithm, string apiKey = null);

        string GetJsPaySign(string appId, string timeStamp, string nonceStr, string package, string key,
            string signType = "MD5");
    }
}