using System;
using System.Threading.Tasks;
using TT.Abp.Weixin.Application.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Weixin.Application
{
    public interface IWeixinAppService : IApplicationService
    {
        Task<string> GetAccessToken(string appid);

        Task<object> MiniAuth(WeChatMiniProgramAuthenticateModel loginModel, string appid = null, string appSec = null);

        Task<object> CheckLogin(bool? dbCheck = false);
    }
}