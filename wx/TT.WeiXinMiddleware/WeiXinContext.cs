using Microsoft.AspNetCore.Http;

namespace TT.WeiXinMiddleware
{
    public class WeiXinContext
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public WeiXinContext(WeiXinMessage message, HttpContext context)
        {
            HttpContext = context;
            this.FromUserName = message.FromUserName;
            this.ToUserName = message.ToUserName;
            this.CreateTime = message.CreateTime;
            this.MsgId = message.MsgId;
            this.MsgType = message.MsgType;
            this.Event = message.Event;
            this.EventKey = message.EventKey;
        }

        /// <summary>
        /// 
        /// </summary>
        public HttpContext HttpContext { get; }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 	消息创建时间 （整型）
        /// </summary>
        public long CreateTime { get; set; }

        /// <summary>
        /// 	消息类型，event
        /// </summary>
        public virtual string MsgType { get; protected set; }


        /// <summary>
        /// 消息ID
        /// </summary>
        public long MsgId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Event { get; }

        /// <summary>
        /// 
        /// </summary>
        public string EventKey { get; }
    }
}