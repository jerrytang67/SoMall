namespace TT.WeiXinMiddleware
{
    public class Constants
    {
        /// <summary>
        /// <![CDATA[授权类型]]>
        /// </summary>
        public static class GRANT_TYPE
        {
            /// <summary>
            /// <![CDATA[client_credential]]]>
            /// </summary>
            public const string CLIENT_CREDENTIAL = "client_credential";
        }

        /// <summary>
        /// 
        /// </summary>
        public static class CACHE
        {
            /// <summary>
            /// 令牌缓存KEY
            /// </summary>
            public const string ACCESS_TOKEN_CACHE_KEY = "ACCESS_TOKEN_CACHE_KEY";
        }

        /// <summary>
        /// 微信事件
        /// </summary>
        public static class EVENT
        {
            /// <summary>
            /// 关注事件
            /// </summary>
            public const string SUBSCRIBE = "subscribe";

            /// <summary>
            /// 取消关注
            /// </summary>
            public const string UNSUBSCRIBE = "unsubscribe";


            /// <summary>
            /// 自定义菜单点击事件
            /// </summary>
            public const string CLICK = "CLICK";

            /// <summary>
            /// 点击链接跳转
            /// </summary>
            public const string VIEW = "VIEW";

            /// <summary>
            /// 扫码事件
            /// </summary>
            public const string SCAN = "SCAN";


            /// <summary>
            /// 上报地理位置
            /// </summary>
            public const string LOCATION = "LOCATION";
        }


        /// <summary>
        /// 消息类型
        /// </summary>
        public static class MSG_TYPE
        {

            /// <summary>
            /// 事件
            /// </summary>
            public const string EVENT = "event";


            /// <summary>
            /// 文本消息
            /// </summary>
            public const string TEXT = "text";


            /// <summary>
            /// 图片消息
            /// </summary>
            public const string IMAGE = "image";


            /// <summary>
            /// 视频消息
            /// </summary>
            public const string VIDEO = "video";

            /// <summary>
            /// 语音消息
            /// </summary>
            public const string VOICE = "voice";


            /// <summary>
            /// 小视频
            /// </summary>
            public const string SHORTVIDEO = "shortvideo";


            /// <summary>
            /// 地理位置
            /// </summary>
            public const string LOCATION = "location";

            /// <summary>
            /// 链接消息
            /// </summary>
            public const string LINK = "link";

        }
    }
}