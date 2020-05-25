using System;
using System.Threading.Tasks;
using TT.HttpClient.Weixin.WeixiinResult;

namespace TT.HttpClient.Weixin
{
    public interface IWeixinApi
    {
        Task<WeixinTokenResult> GetToken(string appid, string appSecret);
        Task<WeixinUserInfoResult> GetUserInfo(string token, string openid);
        Task<MiniSessionResult> Mini_Code2Session(string code, string appid, string appSeret);

        Task<Byte[]> WxacodeGet(string token, string path, int width = 430, bool is_hyaline = false);

        Task<Byte[]> WxacodeGetUnlimit(string token, string scene, string page = "pages/index/index", int width = 430, bool is_hyaline = false);

        Task<TicketResult> GetTicket(string token, string url);
    }
}