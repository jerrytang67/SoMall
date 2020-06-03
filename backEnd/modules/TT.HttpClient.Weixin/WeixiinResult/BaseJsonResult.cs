using System;

namespace TT.HttpClient.Weixin
{
    [Serializable]
    public abstract class BaseJsonResult : IJsonResult
    {
        /// <summary>
        /// 返回结果信息
        /// </summary>
        public virtual string errmsg { get; set; }

        /// <summary>
        /// errcode的
        /// </summary>
        public abstract int ErrorCodeValue { get; }

        public virtual object P2PData { get; set; }
    }
}