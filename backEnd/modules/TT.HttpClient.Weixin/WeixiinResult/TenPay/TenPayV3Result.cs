using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TT.HttpClient.Weixin.WeixiinResult.TenPay
{
    /// <summary>
    ///     基础返回结果（微信支付返回结果基类）
    /// </summary>
    public class TenPayV3Result
    {
        protected XDocument _resultXml;

        public TenPayV3Result(string resultXml)
        {
            _resultXml = XDocument.Parse(resultXml);
            return_code = GetXmlValue("return_code"); // res.Element("xml").Element
            if (!IsReturnCodeSuccess())
            {
                return_msg = GetXmlValue("return_msg"); // res.Element("xml").Element
            }
        }

        public TenPayV3Result(XDocument xml)
        {
            _resultXml = xml;
            return_code = GetXmlValue("return_code"); // res.Element("xml").Element
            if (!IsReturnCodeSuccess())
            {
                return_msg = GetXmlValue("return_msg"); // res.Element("xml").Element
            }
        }

        public string return_code { get; set; }
        public string return_msg { get; set; }

        /// <summary>
        ///     XML内容
        /// </summary>
        public string ResultXml => _resultXml.ToString();

        //StringWriter sw = new StringWriter();
        //XmlTextWriter xmlTextWriter = new XmlTextWriter(sw);
        //_resultXml.WriteTo(xmlTextWriter);
        //return sw.ToString();
        /// <summary>
        ///     获取Xml结果中对应节点的值
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public string GetXmlValue(string nodeName)
        {
            if (_resultXml == null || _resultXml.Element("xml") == null
                                   || _resultXml.Element("xml").Element(nodeName) == null)
            {
                return "";
            }

            return _resultXml.Element("xml").Element(nodeName).Value;
        }

        /// <summary>
        ///     获取Xml结果中对应节点的集合值
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public IList<T> GetXmlValues<T>(string nodeName)
        {
            var result = new List<T>();
            try
            {
                if (_resultXml != null)
                {
                    var xElement = _resultXml.Element("xml");
                    if (xElement != null)
                    {
                        var nodeList = xElement.Elements().Where(z => z.Name.ToString().StartsWith(nodeName));
                        result = nodeList.Cast<T>().ToList();
                    }
                }
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }


        public bool IsReturnCodeSuccess()
        {
            return return_code == "SUCCESS";
        }
    }
}