using System;
using System.Xml.Linq;

namespace TT.HttpClient.Weixin.WeixiinResult.TenPay
{
    /// <summary>
    ///     统一支付接口在return_code 和result_code 都为SUCCESS 的时候有返回详细信息
    /// </summary>
    public class UnifiedorderResult : Result
    {
        ///// <summary>
        ///// 子商户公众账号ID
        ///// </summary>
        //public string sub_appid { get; set; }

        ///// <summary>
        ///// 子商户号
        ///// </summary>
        //public string sub_mch_id { get; set; }

        public UnifiedorderResult(string resultXml)
            : base(resultXml)
        {
            if (IsReturnCodeSuccess())
            {
                device_info = GetXmlValue("device_info") ?? "";
                //sub_appid = GetXmlValue("sub_appid") ?? "";
                //sub_mch_id = GetXmlValue("sub_mch_id") ?? "";

                if (IsResultCodeSuccess())
                {
                    trade_type = GetXmlValue("trade_type") ?? "";
                    prepay_id = GetXmlValue("prepay_id") ?? "";
                    code_url = GetXmlValue("code_url") ?? "";
                    mweb_url = GetXmlValue("mweb_url") ?? "";
                }
            }
        }

        public UnifiedorderResult(XDocument xml)
            : base(xml)
        {
            if (IsReturnCodeSuccess())
            {
                device_info = GetXmlValue("device_info") ?? "";
                //sub_appid = GetXmlValue("sub_appid") ?? "";
                //sub_mch_id = GetXmlValue("sub_mch_id") ?? "";

                if (IsResultCodeSuccess())
                {
                    trade_type = GetXmlValue("trade_type") ?? "";
                    prepay_id = GetXmlValue("prepay_id") ?? "";
                    code_url = GetXmlValue("code_url") ?? "";
                    mweb_url = GetXmlValue("mweb_url") ?? "";
                }

                TimeStamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString();
            }
        }

        /// <summary>
        ///     微信支付分配的终端设备号
        /// </summary>
        public string device_info { get; set; }

        /// <summary>
        ///     交易类型:JSAPI、NATIVE、APP
        /// </summary>
        public string trade_type { get; set; }

        /// <summary>
        ///     微信生成的预支付ID，用于后续接口调用中使用
        /// </summary>
        public string prepay_id { get; set; }

        /// <summary>
        ///     trade_type为NATIVE时有返回，此参数可直接生成二维码展示出来进行扫码支付
        /// </summary>
        public string code_url { get; set; }

        /// <summary>
        ///     在H5支付时返回
        /// </summary>
        public string mweb_url { get; set; }

        public string TimeStamp { get; }

        public string PaySign { get; set; }
    }
}