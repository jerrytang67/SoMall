using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;
using Serilog;
using TT.Extensions;
using TT.HttpClient.Weixin.Models;
using TT.HttpClient.Weixin.Signature;
using TT.HttpClient.Weixin.WeixiinResult.TenPay;

namespace TT.HttpClient.Weixin
{
    public interface IPayApi
    {
        /// <summary>
        ///     <see cref="https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_1" />
        ///     除付款码支付场景以外，商户系统先调用该接口在微信支付服务后台生成预支付交易单，返回正确的预支付交易会话标识后再按不同场景生成交易串调起支付。
        /// </summary>
        /// <param name="appId">服务商商户的 AppId。</param>
        /// <param name="mchId">微信支付分配的商户号。</param>
        /// <param name="key">服务商商户的 key。</param>
        /// <param name="subAppId">微信分配的子商户公众账号 Id。<br />如需在支付完成后获取 <paramref name="subOpenId" /> 则此参数必传。</param>
        /// <param name="subMchId">微信支付分配的子商户号。</param>
        /// <param name="deviceInfo">终端设备号 (门店号或收银设备 Id)，注意：PC 网页或 JSAPI 支付请传 "WEB"。</param>
        /// <param name="receipt">传入 Y 时，支付成功消息和支付详情页将出现开票入口。需要在微信支付商户平台或微信公众平台开通电子发票功能，传此字段才可生效。</param>
        /// <param name="body">具体的商品描述信息，建议根据不同的场景传递不同的描述信息。</param>
        /// <param name="detail">商品详细描述，对于使用单品优惠的商户，该字段必须按照规范上传。</param>
        /// <param name="attach">附加数据，在查询 API 和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据。</param>
        /// <param name="outTradeNo">商户系统内部订单号，要求 32 个字符内，只能是数字、大小写字母_-|* 且在同一个商户号下唯一。</param>
        /// <param name="feeType">符合 ISO 4217 标准的三位字母代码，默认人民币：CNY。</param>
        /// <param name="totalFee">订单总金额，只能为整数，单位是分。</param>
        /// <param name="billCreateIp">调用微信支付 API 的机器 IP，可以使用 IPv4 或 IPv6。</param>
        /// <param name="timeStart">订单生成时间，格式为 yyyyMMddHHmmss。</param>
        /// <param name="timeExpire">订单失效时间，格式为 yyyyMMddHHmmss。</param>
        /// <param name="goodsTag">订单优惠标记，代金券或立减优惠功能的参数。</param>
        /// <param name="notifyUrl">接收微信支付异步通知回调地址，通知 Url 必须为直接可访问的 Url，不能携带参数。</param>
        /// <param name="tradeType">交易类型，请参考 <see cref="Consts.TradeType" /> 的定义。</param>
        /// <param name="productId">当 <paramref name="tradeType" /> 参数为 <see cref="Consts.TradeType.Native" /> 时，此参数必填。</param>
        /// <param name="limitPay">指定支付方式，传递 no_credit 则说明不能使用信用卡支付。</param>
        /// <param name="openId">当 <paramref name="tradeType" /> 参数为 <see cref="Consts.TradeType.JsApi" /> 时，此参数必填。如果选择传 <paramref name="subOpenId" />, 则必须传 <paramref name="subAppId" />。</param>
        /// <param name="subOpenId">当 <paramref name="tradeType" /> 参数为 <see cref="Consts.TradeType.JsApi" /> 时，此参数必填。如果选择传 <paramref name="subOpenId" />, 则必须传 <paramref name="subAppId" />。</param>
        /// <param name="sceneInfo">该字段常用于线下活动时的场景信息上报，支持上报实际门店信息，商户也可以按需求自己上报相关信息。</param>
        Task<UnifiedorderResult> UnifiedOrderAsync(
            string appId,
            string mchId,
            string mchKey,
            string body, string outTradeNo, int totalFee, string notifyUrl, string tradeType,
            string openId = "",
            string billCreateIp = "",
            string subAppId = "",
            string subMchId = "",
            string deviceInfo = "", string receipt = "",
            string detail = "", string attach = "", string feeType = "",
            string timeStart = "", string timeExpire = "", string goodsTag = "",
            string productId = "",
            string limitPay = "", string subOpenId = "", string sceneInfo = "");


        Task<bool> RefundAsync(string appId, string mchId, string mchKey, string subAppId, string subMchId,
            string transactionId, string outTradeNo, string outRefundNo,
            int totalFee, int refundFee, string refundFeeType = "CNY", string refundDesc = "",
            string refundAccount = "REFUND_SOURCE_UNSETTLED_FUNDS",
            string notifyUrl = "");

        Task<bool> Transfers(string mch_appid, string mchid, string mchKey, string partner_trade_no,
            string openid, string re_user_name, int amount, string desc, bool check_name = true);
    }

    public class PayApi : IPayApi
    {
        private readonly System.Net.Http.HttpClient _client;
        private readonly ISignatureGenerator _signatureGenerator;

        public PayApi
        (System.Net.Http.HttpClient client,
            ISignatureGenerator signatureGenerator
        )
        {
            _client = client;
            _signatureGenerator = signatureGenerator;
        }

        /// <summary>
        ///     <see cref="https://pay.weixin.qq.com/wiki/doc/api/jsapi.php?chapter=9_1" />
        ///     除付款码支付场景以外，商户系统先调用该接口在微信支付服务后台生成预支付交易单，返回正确的预支付交易会话标识后再按不同场景生成交易串调起支付。
        /// </summary>
        /// <param name="appId">服务商商户的 AppId。</param>
        /// <param name="mchId">微信支付分配的商户号。</param>
        /// <param name="key">服务商商户的 key。</param>
        /// <param name="subAppId">微信分配的子商户公众账号 Id。<br />如需在支付完成后获取 <paramref name="subOpenId" /> 则此参数必传。</param>
        /// <param name="subMchId">微信支付分配的子商户号。</param>
        /// <param name="deviceInfo">终端设备号 (门店号或收银设备 Id)，注意：PC 网页或 JSAPI 支付请传 "WEB"。</param>
        /// <param name="receipt">传入 Y 时，支付成功消息和支付详情页将出现开票入口。需要在微信支付商户平台或微信公众平台开通电子发票功能，传此字段才可生效。</param>
        /// <param name="body">具体的商品描述信息，建议根据不同的场景传递不同的描述信息。</param>
        /// <param name="detail">商品详细描述，对于使用单品优惠的商户，该字段必须按照规范上传。</param>
        /// <param name="attach">附加数据，在查询 API 和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据。</param>
        /// <param name="outTradeNo">商户系统内部订单号，要求 32 个字符内，只能是数字、大小写字母_-|* 且在同一个商户号下唯一。</param>
        /// <param name="feeType">符合 ISO 4217 标准的三位字母代码，默认人民币：CNY。</param>
        /// <param name="totalFee">订单总金额，只能为整数，单位是分。</param>
        /// <param name="billCreateIp">调用微信支付 API 的机器 IP，可以使用 IPv4 或 IPv6。</param>
        /// <param name="timeStart">订单生成时间，格式为 yyyyMMddHHmmss。</param>
        /// <param name="timeExpire">订单失效时间，格式为 yyyyMMddHHmmss。</param>
        /// <param name="goodsTag">订单优惠标记，代金券或立减优惠功能的参数。</param>
        /// <param name="notifyUrl">接收微信支付异步通知回调地址，通知 Url 必须为直接可访问的 Url，不能携带参数。</param>
        /// <param name="tradeType">交易类型，请参考 <see cref="Consts.TradeType" /> 的定义。</param>
        /// <param name="productId">当 <paramref name="tradeType" /> 参数为 <see cref="Consts.TradeType.Native" /> 时，此参数必填。</param>
        /// <param name="limitPay">指定支付方式，传递 no_credit 则说明不能使用信用卡支付。</param>
        /// <param name="openId">当 <paramref name="tradeType" /> 参数为 <see cref="Consts.TradeType.JsApi" /> 时，此参数必填。如果选择传 <paramref name="subOpenId" />, 则必须传 <paramref name="subAppId" />。</param>
        /// <param name="subOpenId">当 <paramref name="tradeType" /> 参数为 <see cref="Consts.TradeType.JsApi" /> 时，此参数必填。如果选择传 <paramref name="subOpenId" />, 则必须传 <paramref name="subAppId" />。</param>
        /// <param name="sceneInfo">该字段常用于线下活动时的场景信息上报，支持上报实际门店信息，商户也可以按需求自己上报相关信息。</param>
        public async Task<UnifiedorderResult> UnifiedOrderAsync(
            string appId,
            string mchId,
            string mchKey,
            string body, string outTradeNo, int totalFee, string notifyUrl, string tradeType,
            string openId = "",
            string billCreateIp = "",
            string subAppId = "",
            string subMchId = "",
            string deviceInfo = "", string receipt = "",
            string detail = "", string attach = "", string feeType = "",
            string timeStart = "", string timeExpire = "", string goodsTag = "",
            string productId = "",
            string limitPay = "", string subOpenId = "", string sceneInfo = "")
        {
            if (tradeType == Consts.TradeType.JsApi && string.IsNullOrEmpty(openId)) throw new ArgumentException($"当交易类型为 JsApi 时，参数 {nameof(openId)} 必须传递有效值。");

            if (!string.IsNullOrEmpty(subOpenId) && string.IsNullOrEmpty(subAppId)) throw new ArgumentException($"传递子商户的 OpenId 时，参数 {nameof(subAppId)} 必须传递有效值。");

            var request = new PayParameters();
            request.AddParameter("appid", appId);
            request.AddParameter("mch_id", mchId);
            request.AddParameter("sub_appid", subAppId);
            request.AddParameter("sub_mch_id", subMchId);
            request.AddParameter("device_info", deviceInfo);
            request.AddParameter("nonce_str", RandomExt.GetRandom());


            request.AddParameter("sign_type", "MD5");
            request.AddParameter("body", body);
            request.AddParameter("detail", detail);
            request.AddParameter("attach", attach);
            request.AddParameter("out_trade_no", outTradeNo);
            request.AddParameter("fee_type", feeType);
            request.AddParameter("total_fee", totalFee);
            request.AddParameter("spbill_create_ip", billCreateIp);
            request.AddParameter("time_start", timeStart);
            request.AddParameter("time_expire", timeExpire);
            request.AddParameter("goods_tag", goodsTag);
            request.AddParameter("notify_url", notifyUrl);
            request.AddParameter("trade_type", tradeType);
            request.AddParameter("product_id", productId);
            request.AddParameter("limit_pay", limitPay);
            request.AddParameter("openid", openId);
            request.AddParameter("receipt", receipt);
            request.AddParameter("scene_info", sceneInfo);
            request.AddParameter("sub_openid", subOpenId);
            //request.AddParameter("key", mchKey);

            var signStr = _signatureGenerator.Generate(request, MD5.Create(), mchKey);
            request.AddParameter("sign", signStr);

            var xmlResult = await RequestAndGetReturnValueAsync("pay/unifiedorder", request);
            var result = new UnifiedorderResult(xmlResult);

            var package = $"prepay_id={result.prepay_id}";
            result.PaySign = _signatureGenerator.GetJsPaySign(
                subAppId.IsNullOrEmptyOrWhiteSpace() ? appId : subAppId, //如果是服务商模式,这里是SubAppId
                result.TimeStamp,
                result.nonce_str,
                package, mchKey);

            return result;
        }


        /// <summary>
        ///     当交易发生之后一段时间内，由于买家或者卖家的原因需要退款时，卖家可以通过退款接口将支付款退还给买家，微信支付将在收到退款请求并且验证成功之后，按照退款规则将
        ///     支付款按原路退到买家帐号上。
        /// </summary>
        /// <remarks>
        ///     注意：<br />
        ///     1. 交易时间超过一年的订单无法提交退款。<br />
        ///     2. 微信支付退款支持单笔交易分多次退款，多次退款需要提交原支付订单的商户订单号和设置不同的退款单号。申请退款总金额不能超过订单金额。 一笔退款失败后重新提交，请
        ///     不要更换退款单号，请使用原商户退款单号。<br />
        ///     3. 请求频率限制：150 QPS，即每秒钟正常的申请退款请求次数不超过 150 次。<br />
        ///     错误或无效请求频率限制：6 QPS，即每秒钟异常或错误的退款申请请求不超过 6 次。<br />
        ///     4. 每个支付订单的部分退款次数不能超过 50 次。
        /// </remarks>
        /// <param name="appId">服务商商户的 AppId。</param>
        /// <param name="mchId">微信支付分配的商户号。</param>
        /// <param name="subAppId">微信分配的子商户公众账号 Id。</param>
        /// <param name="subMchId">微信支付分配的子商户号。</param>
        /// <param name="transactionId">微信生成的订单号，在支付通知中有返回。</param>
        /// <param name="outTradeNo">
        ///     商户系统内部订单号，要求 32 个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。<br />
        ///     <paramref name="transactionId" /> 与 <paramref name="outTradeNo" /> 二选一，如果同时存在，优先级是：<paramref name="transactionId" /> 大于 <paramref name="outTradeNo" />。
        /// </param>
        /// <param name="outRefundNo">商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。</param>
        /// <param name="totalFee">订单总金额，单位为分，只能为整数。</param>
        /// <param name="refundFee">退款总金额，单位为分，只能为整数，可部分退款。</param>
        /// <param name="refundFeeType">退款货币类型，需与支付一致，或者不填。</param>
        /// <param name="refundDesc">若商户传入，会在下发给用户的退款消息中体现退款原因，当订单退款金额 ≤1 元并且属于部分退款，则不会在退款消息中体现退款原因。</param>
        /// <param name="refundAccount">仅针对老资金流商户使用，具体参考 <see cref="RefundAccountType" /> 的定义。</param>
        /// <param name="notifyUrl">异步接收微信支付退款结果通知的回调地址，通知 Url 必须为外网可访问的 Url，不允许带参数。如果传递了该参数，则商户平台上配置的回调地址将不会生效。</param>
        public async Task<bool> RefundAsync(string appId, string mchId, string mchKey, string subAppId, string subMchId,
            string transactionId, string outTradeNo, string outRefundNo,
            int totalFee, int refundFee, string refundFeeType = "CNY", string refundDesc = "",
            string refundAccount = "REFUND_SOURCE_UNSETTLED_FUNDS",
            string notifyUrl = "")
        {
            var request = new PayParameters();
            request.AddParameter("appid", appId);
            request.AddParameter("mch_id", mchId);
            request.AddParameter("sub_appid", subAppId);
            request.AddParameter("sub_mch_id", subMchId);
            request.AddParameter("nonce_str", RandomExt.GetRandom());
            request.AddParameter("transaction_id", transactionId);
            request.AddParameter("out_trade_no", outTradeNo);
            request.AddParameter("out_refund_no", outRefundNo);
            request.AddParameter("total_fee", totalFee);
            request.AddParameter("refund_fee", refundFee);
            request.AddParameter("refund_fee_type", refundFeeType);
            request.AddParameter("refund_desc", refundDesc);
            request.AddParameter("refund_account", refundAccount);
            request.AddParameter("notify_url", notifyUrl);

            var signStr = _signatureGenerator.Generate(request, MD5.Create(), mchKey);
            request.AddParameter("sign", signStr);

            var xmlResult = await RequestAndGetReturnValueAsync("secapi/pay/refund", request);

            var returnCode = GetXmlNodeString(xmlResult, "return_code");
            var resultode = GetXmlNodeString(xmlResult, "result_code");

            if (returnCode == "SUCCESS" && resultode == "SUCCESS") return await Task.FromResult(true);

            throw new Exception(GetXmlNodeString(xmlResult, "return_msg"));

            // <xml>
            // <return_code><![CDATA[SUCCESS]]></return_code>
            // <return_msg><![CDATA[OK]]></return_msg>
            // <appid><![CDATA[xxxxxxx]]></appid>
            // <mch_id><![CDATA[1486627732]]></mch_id>
            // <nonce_str><![CDATA[OfZFrlSjl69xe2mI]]></nonce_str>
            // <sign><![CDATA[D6483C34CEDD51219C85756B6EB7E5D2]]></sign>
            // <result_code><![CDATA[SUCCESS]]></result_code>
            // <transaction_id><![CDATA[4200000561202004275609032072]]></transaction_id>
            // <out_trade_no><![CDATA[148662773220200427222405181738]]></out_trade_no>
            // <out_refund_no><![CDATA[RZ1jDsdbg1xAbzn1KOf4zA]]></out_refund_no>
            // <refund_id><![CDATA[50300003912020051500539875618]]></refund_id>
            // <refund_channel><![CDATA[]]></refund_channel>
            // <refund_fee>2</refund_fee>
            // <coupon_refund_fee>0</coupon_refund_fee>
            // <total_fee>2</total_fee>
            // <cash_fee>2</cash_fee>
            // <coupon_refund_count>0</coupon_refund_count>
            // <cash_refund_fee>2</cash_refund_fee>
            // </xml>
        }

        public static string GetXmlNodeString(XDocument xml, string nodeName)
        {
            return xml.Element("xml")?.Element(nodeName)?.Value;
        }

        /// <summary>
        ///     该接口提供所有微信支付订单的查询，商户可以通过该接口主动查询订单状态，完成下一步的业务逻辑。<br />
        ///     需要调用查询接口的情况：<br />
        ///     1. 当商户后台、网络、服务器等出现异常，商户系统最终未接收到支付通知。<br />
        ///     2. 调用支付接口后，返回系统错误或未知交易状态情况。<br />
        ///     3. 调用被扫支付 API，返回 USERPAYING 的状态。<br />
        ///     4. 调用关单或撤销接口 API 之前，需确认支付状态。
        /// </summary>
        /// <param name="appId">服务商商户的 AppId。</param>
        /// <param name="mchId">微信支付分配的商户号。</param>
        /// <param name="subAppId">微信分配的子商户公众账号 Id。</param>
        /// <param name="subMchId">微信支付分配的子商户号。</param>
        /// <param name="transactionId">微信生成的订单号，在支付通知中有返回。</param>
        /// <param name="outTradeNo">
        ///     商户系统内部订单号，要求 32 个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。<br />
        ///     <paramref name="transactionId" /> 与 <paramref name="outTradeNo" /> 二选一，如果同时存在，优先级是：<paramref name="transactionId" /> 大于 <paramref name="outTradeNo" />。
        /// </param>
        public Task<XDocument> OrderQueryAsync(string appId, string mchId, string subAppId, string subMchId,
            string transactionId, string outTradeNo)
        {
            var request = new PayParameters();
            request.AddParameter("appid", appId);
            request.AddParameter("mch_id", mchId);
            request.AddParameter("sub_appid", subAppId);
            request.AddParameter("sub_mch_id", subMchId);
            request.AddParameter("nonce_str", RandomExt.GetRandom());
            request.AddParameter("transaction_id", transactionId);
            request.AddParameter("out_trade_no", outTradeNo);

            var signStr = _signatureGenerator.Generate(request, MD5.Create());
            request.AddParameter("sign", signStr);

            return RequestAndGetReturnValueAsync("pay/orderquery", request);
        }

        /// <summary>
        ///     以下情况需要调用关单接口：<br />
        ///     1. 商户订单支付失败需要生成新单号重新发起支付，要对原订单号调用关单，避免重复支付。<br />
        ///     2. 系统下单后，用户支付超时，系统退出不再受理，避免用户继续，请调用关单接口。<br />
        /// </summary>
        /// <param name="appId">服务商商户的 AppId。</param>
        /// <param name="mchId">微信支付分配的商户号。</param>
        /// <param name="subAppId">微信分配的子商户公众账号 Id。</param>
        /// <param name="subMchId">微信支付分配的子商户号。</param>
        /// <param name="outTradeNo">商户系统内部订单号，要求 32 个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。</param>
        /// <returns></returns>
        public Task<XDocument> CloseOrderAsync(string appId, string mchId, string subAppId, string subMchId,
            string outTradeNo)
        {
            var request = new PayParameters();
            request.AddParameter("appid", appId);
            request.AddParameter("mch_id", mchId);
            request.AddParameter("sub_appid", subAppId);
            request.AddParameter("sub_mch_id", subMchId);
            request.AddParameter("nonce_str", RandomExt.GetRandom());
            request.AddParameter("out_trade_no", outTradeNo);

            var signStr = _signatureGenerator.Generate(request, MD5.Create());
            request.AddParameter("sign", signStr);

            return RequestAndGetReturnValueAsync("pay/closeorder", request);
        }


        /// <summary>
        ///     提交退款申请后，通过调用该接口查询退款状态。退款有一定延时，用零钱支付的退款 20 分钟内到账，银行卡支付的退款 3 个工作日后重新查询退款状态。
        /// </summary>
        /// <remarks>
        ///     注意：如果单个支付订单部分退款次数超过 20 次请使用退款单号查询。<br />
        ///     当一个订单部分退款超过 10 笔后，商户用微信订单号或商户订单号调退款查询 API 查询退款时，默认返回前 10 笔和 total_refund_count（退款单总笔数）。<br />
        ///     商户需要查询同一订单下超过 10 笔的退款单时，可传入订单号及 offset 来查询，微信支付会返回 offset 及后面的 10 笔，以此类推。<br />
        ///     当商户传入的 offset 超过 total_refund_count，则系统会返回报错 PARAM_ERROR。
        /// </remarks>
        /// <param name="appId">服务商商户的 AppId。</param>
        /// <param name="mchId">微信支付分配的商户号。</param>
        /// <param name="subAppId">微信分配的子商户公众账号 Id。</param>
        /// <param name="subMchId">微信支付分配的子商户号。</param>
        /// <param name="transactionId">微信订单号。</param>
        /// <param name="outTradeNo">商户系统内部订单号，要求 32 个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。</param>
        /// <param name="outRefundNo">商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。</param>
        /// <param name="refundId">微信退款单号。</param>
        /// <param name="offset">偏移量，当部分退款次数超过 10 次时可使用，表示返回的查询结果从这个偏移量开始取记录。</param>
        public Task<XDocument> RefundQueryAsync(string appId, string mchId, string subAppId, string subMchId,
            string transactionId, string outTradeNo, string outRefundNo,
            string refundId, int offset)
        {
            var request = new PayParameters();
            request.AddParameter("appid", appId);
            request.AddParameter("mch_id", mchId);
            request.AddParameter("sub_appid", subAppId);
            request.AddParameter("sub_mch_id", subMchId);
            request.AddParameter("nonce_str", RandomExt.GetRandom());
            request.AddParameter("transaction_id", transactionId);
            request.AddParameter("out_trade_no", outTradeNo);
            request.AddParameter("out_refund_no", outRefundNo);
            request.AddParameter("refund_id", refundId);
            request.AddParameter("out_trade_no", offset);

            var signStr = _signatureGenerator.Generate(request, MD5.Create());
            request.AddParameter("sign", signStr);

            return RequestAndGetReturnValueAsync("pay/refundquery", request);
        }


        protected virtual async Task<XDocument> RequestAndGetReturnValueAsync(string targetUrl,
            PayParameters requestParameters)
        {
            var result = await RequestAsync(targetUrl, requestParameters.ToXmlStr());

            if (result.Element("xml").Element("return_code").Value != "SUCCESS")
            {
                var errMsg =
                        "微信支付接口调用失败，具体失败原因：" +
                        result.Element("xml").Element("return_msg").Value
                    ;

                var exception = new Exception(errMsg);
                exception.Data.Add(nameof(targetUrl), targetUrl);
                exception.Data.Add(nameof(result), result.ToString());

                throw exception;
            }

            Log.Information(result.ToString(), "TenPay_XmlResult");
            return result;
        }


        protected virtual async Task<XDocument> RequestAndGetReturnValueAsync2(string targetUrl,
            PayParameters requestParameters)
        {
            var result = await RequestAsync(targetUrl, requestParameters.ToXmlStr());

            if (result.Element("xml").Element("return_code").Value != "SUCCESS")
            {
                var errMsg =
                        "微信支付接口调用失败，具体失败原因：" +
                        result.Element("xml").Element("return_msg").Value
                    ;

                var exception = new Exception(errMsg);
                exception.Data.Add(nameof(targetUrl), targetUrl);
                exception.Data.Add(nameof(result), result.ToString());

                throw exception;
            }

            Log.Information(result.ToString(), "TenPay_XmlResult");
            return result;
        }


        #region 企业付款

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mch_appid"></param>
        /// <param name="mchid"></param>
        /// <param name="nonce_str"></param>
        /// <param name="partner_trade_no"></param>
        /// <param name="openid"></param>
        /// <param name="re_user_name"></param>
        /// <param name="amount"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public async Task<bool> Transfers(string mch_appid, string mchid, string mchKey, string partner_trade_no,
            string openid, string re_user_name, int amount, string desc, bool check_name = true)
        {
            var request = new PayParameters();
            request.AddParameter("mch_appid", mch_appid);
            request.AddParameter("mchid", mchid);
            request.AddParameter("nonce_str", RandomExt.GetRandom());
            request.AddParameter("partner_trade_no", partner_trade_no);
            request.AddParameter("openid", openid);

            request.AddParameter("check_name", check_name ? "FORCE_CHECK" : "NO_CHECK");

            request.AddParameter("re_user_name", re_user_name);
            request.AddParameter("amount", amount);
            request.AddParameter("desc", desc);

            var signStr = _signatureGenerator.Generate(request, MD5.Create(), mchKey);
            request.AddParameter("sign", signStr);
            var xmlResult = await RequestAndGetReturnValueAsync2("mmpaymkttransfers/promotion/transfers", request);

            var returnCode = GetXmlNodeString(xmlResult, "return_code");
            var resultode = GetXmlNodeString(xmlResult, "result_code");

            if (returnCode == "SUCCESS" && resultode == "SUCCESS")
                return true;

            var s = GetXmlNodeString(xmlResult, "err_code");
            throw new Exception(xmlResult.ToString()
                // GetXmlNodeString(xmlResult, "err_code")
            );
        }

        #endregion


        public async Task<XDocument> RequestAsync(string url, string body)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(body)
            };

            var responseMessage = await _client.SendAsync(request);
            if (responseMessage.StatusCode == HttpStatusCode.GatewayTimeout)
                throw new HttpRequestException("微信支付网关超时，请稍后重试。");
            var readAsString = await responseMessage.Content.ReadAsStringAsync();

            var newXmlDocument = XDocument.Parse(readAsString);
            return newXmlDocument;
        }


        internal X509Certificate2 GetMyX509Certificate(string certName)
        {
            var store = new X509Store("Wetrial", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var cert = store.Certificates.Find(X509FindType.FindBySubjectName, certName, false)[0];
            return cert;
        }
    }
}