namespace TT.HttpClient.Weixin.WeixiinResult
{
    public class TicketResult : BaseWeChatReulst
    {
        public string ticket { get; set; }
        public int expires_in { get; set; }
    }
}