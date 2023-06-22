namespace TT.HttpClient.Weixin
{
    public class MiniSessionResult
    {
        public string openid { get; set; }

        public string unionid { get; set; }
        public string session_key { get; set; }

        public int errcode { get; set; }
        
        public string errmsg { get; set; }
    }
}