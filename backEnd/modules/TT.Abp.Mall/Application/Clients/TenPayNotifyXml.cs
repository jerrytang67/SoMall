using System.Xml.Serialization;

namespace TT.Abp.Mall.Application.Clients
{
    [XmlRoot("xml")]
    public class TenPayNotifyXml : TenPayResult
    {
        //just return_code success
        public string appid { get; set; }
        public string mch_id { get; set; }
        public string device_info { get; set; }
        public string nonce_str { get; set; }
        public string sign { get; set; }
        public string result_code { get; set; }
        public string err_code { get; set; }
        public string err_code_des { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string trade_type { get; set; } //JSAPI、NATIVE、APP

        /// <summary>
        /// 付款银行 ,银行类型，采用字符串类型的银行标识，银行类型见银行列表 
        /// </summary>
        public string bank_type { get; set; }

        /// <summary>
        /// is_subscribe 用户是否关注公众账号，Y-关注，N-未关注
        /// </summary>
        public string is_subscribe { get; set; }

        public string openid { get; set; }

        public string total_fee { get; set; }
        public int settlement_total_fee { get; set; }
        public string fee_type { get; set; }
        public string cash_fee { get; set; }
        public string cash_fee_type { get; set; }

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        public string transaction_id { get; set; }

        /// <summary>
        /// 商户订单号	
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 支付完成时间	
        /// </summary>
        public string time_end { get; set; }
    }
}