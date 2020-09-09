namespace TT.HttpClient.Weixin
{
    /// <summary>
    ///     所有 JSON 格式返回值的API返回结果接口
    /// </summary>
    public interface IJsonResult // : IJsonResultCallback
    {
        /// <summary>
        ///     返回结果信息
        /// </summary>
        string errmsg { get; set; }

        /// <summary>
        ///     errcode的
        /// </summary>
        int ErrorCodeValue { get; }

        object P2PData { get; set; }
    }
}