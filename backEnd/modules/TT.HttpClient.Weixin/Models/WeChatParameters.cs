using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TT.HttpClient.Weixin.Models
{
    public class PayParameters
    {
        private SortedDictionary<string, string> SortedDictionary { get; }

        public PayParameters()
        {
            SortedDictionary = new SortedDictionary<string, string>(StringComparer.Ordinal);
        }


        public virtual void AddParameter(string key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            if (SortedDictionary.ContainsKey(key))
            {
                return;
            }

            SortedDictionary.Add(key, value);
        }

        public virtual void AddParameter<T>(string key, T intValue)
        {
            SortedDictionary.Add(key, intValue.ToString());
        }

        public virtual string GetWaitForSignatureStr()
        {
            var sb = new StringBuilder();
            foreach (var kv in SortedDictionary)
            {
                sb.Append(kv.Key).Append('=').Append(kv.Value).Append('&');
            }

            return sb.ToString().TrimEnd('&');
        }

        /// <summary>
        /// 将存储的所有参数和值以 XML 格式输出。
        /// </summary>
        public virtual string ToXmlStr()
        {
            var xElement = new XElement(
                "xml",
                SortedDictionary.Select(kv => new XElement(kv.Key, kv.Value))
            );

            using var memoryStream = new MemoryStream();
            xElement.Save(memoryStream);
            memoryStream.Position = 0;

            using StreamReader reader = new StreamReader(memoryStream);

            return reader.ReadToEnd();
        }
    }
}