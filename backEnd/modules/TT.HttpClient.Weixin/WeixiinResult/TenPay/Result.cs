using System.Xml.Linq;

namespace TT.HttpClient.Weixin.WeixiinResult.TenPay
{
    /// <summary>
    ///     统一支付接口在 return_code为 SUCCESS的时候有返回
    /// </summary>
    public class Result : TenPayV3Result
    {
        public Result(string resultXml)
            : base(resultXml)
        {
            result_code = GetXmlValue("result_code"); // res.Element("xml").Element

            if (IsReturnCodeSuccess())
            {
                appid = GetXmlValue("appid") ?? "";
                mch_id = GetXmlValue("mch_id") ?? "";

                #region 服务商

                sub_appid = GetXmlValue("sub_appid") ?? "";
                sub_mch_id = GetXmlValue("sub_mch_id") ?? "";

                #endregion

                nonce_str = GetXmlValue("nonce_str") ?? "";
                sign = GetXmlValue("sign") ?? "";
                err_code = GetXmlValue("err_code") ?? "";
                err_code_des = GetXmlValue("err_code_des") ?? "";
            }
        }

        public Result(XDocument xml)
            : base(xml)
        {
            result_code = GetXmlValue("result_code"); // res.Element("xml").Element

            if (IsReturnCodeSuccess())
            {
                appid = GetXmlValue("appid") ?? "";
                mch_id = GetXmlValue("mch_id") ?? "";

                #region 服务商

                sub_appid = GetXmlValue("sub_appid") ?? "";
                sub_mch_id = GetXmlValue("sub_mch_id") ?? "";

                #endregion

                nonce_str = GetXmlValue("nonce_str") ?? "";
                sign = GetXmlValue("sign") ?? "";
                err_code = GetXmlValue("err_code") ?? "";
                err_code_des = GetXmlValue("err_code_des") ?? "";
            }
        }

        /// <summary>
        ///     微信分配的公众账号ID（付款到银行卡接口，此字段不提供）
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        ///     微信支付分配的商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        ///     随机字符串，不长于32 位
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        ///     签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        ///     SUCCESS/FAIL
        /// </summary>
        public string result_code { get; set; }

        public string err_code { get; set; }
        public string err_code_des { get; set; }


        /// <summary>
        ///     result_code == "SUCCESS"
        /// </summary>
        /// <returns></returns>
        public bool IsResultCodeSuccess()
        {
            return result_code == "SUCCESS";
        }

        #region 服务商

        /// <summary>
        ///     子商户公众账号ID
        /// </summary>
        public string sub_appid { get; set; }

        /// <summary>
        ///     子商户号
        /// </summary>
        public string sub_mch_id { get; set; }

        #endregion
    }
}