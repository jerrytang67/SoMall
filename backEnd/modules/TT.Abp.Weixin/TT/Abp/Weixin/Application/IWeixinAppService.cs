using System.Threading.Tasks;
using TT.Abp.Weixin.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Weixin.Application
{
    public interface IWeixinAppService : IApplicationService
    {
        Task<string> GetAccessToken(string appid);

        Task<object> MiniAuth(WeChatMiniProgramAuthenticateModel loginModel, string appName);

        Task<object> CheckLogin(bool? dbCheck = false);
        Task<JssdkResultDto> GetJssdk(string url, string appName);
        Task<object> GetOAuth(string code, string appName);
    }
}