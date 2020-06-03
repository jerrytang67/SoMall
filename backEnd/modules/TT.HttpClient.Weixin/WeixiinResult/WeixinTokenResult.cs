using TT.HttpClient.Weixin.WeixiinResult;

namespace TT.HttpClient.Weixin
{
    public class WeixinTokenResult : BaseWeChatReulst
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}