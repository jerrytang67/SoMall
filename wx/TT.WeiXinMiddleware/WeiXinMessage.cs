namespace TT.WeiXinMiddleware
{
    public class WeiXinMessage
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public long CreateTime { get; set; }
        public virtual string MsgType { get; protected set; }
        public long MsgId { get; set; }
        public string Event { get; set; }
        public string EventKey { get; set; }
        public string Content { get; set; }
    }
}