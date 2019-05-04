using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TT.WeiXinMiddleware
{
    public class WeiXinOptions
    {
        private IWeiXinProvider _provider = null;
        public string NotifyPath { get; set; }

        public IWeiXinProvider Provider
        {
            get
            {
                return _provider;
            }
            set
            {
                _provider = value;
                _provider.Options = this;
            }
        }


        /// <summary>
        /// <![CDATA[当接收到消息时]]>
        /// </summary>
        public Func<HttpContext, Task> OnRecieveAsync { get; set; }

        /// <summary>
        /// <![CDATA[扫描事件]]>
        /// </summary>
        public Func<WeiXinContext, Task> OnScanAsync { get; set; }

        /// <summary>
        /// <![CDATA[关注事件]]>
        /// </summary>
        public Func<WeiXinContext, Task> OnSubscribeAsync { get; set; }

        /// <summary>
        /// <![CDATA[取消关注]]>
        /// </summary>
        public Func<WeiXinContext, Task> OnUnsubscribeAsync { get; set; }

        /// <summary>
        /// <![CDATA[菜单点击事件]]>
        /// </summary>
        public Func<WeiXinContext, Task> OnClickAsync { get; set; }

        /// <summary>
        /// <![CDATA[点击链接]]>
        /// </summary>
        public Func<WeiXinContext, Task> OnViewAsync { get; set; }

        /// <summary>
        /// <![CDATA[上报地理位置]]>
        /// </summary>
        public Func<WeiXinContext, Task> OnLocationAsync { get; set; }

        /// <summary>
        /// <![CDATA[被动接收普通消息]]>
        /// </summary>
        public Func<HttpContext, Task> OnRecieveMessageAsync { get; set; }
    }
}