using System;

namespace TT.HttpClient.Weixin
{
    /// <summary>
    /// 公众号 JSON 返回结果（用于菜单接口等）
    /// </summary>
    [Serializable]
    public class WxJsonResult : BaseJsonResult
    {
        public int errcode { get; set; }

        /// <summary>
        /// 返回消息代码数字（同errcode枚举值）
        /// </summary>
        public override int ErrorCodeValue => (int) errcode;

        public override string ToString() =>
            $"WxJsonResult：{{errcode:'{(int) errcode}',errcode_name:'{errcode}',errmsg:'{errmsg}'}}";
    }
}