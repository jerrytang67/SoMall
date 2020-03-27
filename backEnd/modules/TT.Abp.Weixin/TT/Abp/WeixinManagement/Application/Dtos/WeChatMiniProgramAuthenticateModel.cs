namespace TT.Abp.WeixinManagement.Application.Dtos
{
    public class WeChatMiniProgramAuthenticateModel
    {
        /// <summary>
        /// 用于换取微信的session_key
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 解密Userinfo使用
        /// </summary>
        public string encryptedData { get; set; }

        public string iv { get; set; }

        public string session_key { get; set; }
    }
}