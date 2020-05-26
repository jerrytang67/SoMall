namespace TT.Abp.Weixin.Application.Dtos
{
    public class JssdkResultDto
    {
        public JssdkResultDto(string appId, string timestamp, string nonceStr, string signature)
        {
            this.appId = appId;
            this.timestamp = timestamp;
            this.nonceStr = nonceStr;
            this.signature = signature;
        }
        public string appId { get; protected set; }
        public string timestamp { get; protected set; }
        public string nonceStr { get; protected set; }
        public string signature { get; protected set; }
    }
}