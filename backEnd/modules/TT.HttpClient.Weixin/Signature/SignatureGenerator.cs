using System.Security.Cryptography;
using System.Text;
using TT.HttpClient.Weixin.Models;

namespace TT.HttpClient.Weixin.Signature
{
    public class SignatureGenerator : ISignatureGenerator
    {
        public string Generate(PayParameters parameters, HashAlgorithm hashAlgorithm, string apiKey = null)
        {
            var signStr = $"{parameters.GetWaitForSignatureStr()}{(apiKey != null ? $"&key={apiKey}" : "")}";
            var signBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(signStr));
            // Log.Information(signStr);
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
            var pay = new PayParameters();
            pay.AddParameter("appId", appId);
            pay.AddParameter("timeStamp", timeStamp);
            pay.AddParameter("nonceStr", nonceStr);
            pay.AddParameter("package", package);
            pay.AddParameter("signType", signType);
            return Generate(pay, MD5.Create(), key);
        }
    }
}