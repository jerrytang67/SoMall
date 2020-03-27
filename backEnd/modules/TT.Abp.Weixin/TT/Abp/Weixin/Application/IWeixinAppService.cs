using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Weixin.Application
{
    public interface IWeixinAppService : IApplicationService
    {
        Task<string> GetAccessToken(string appid);
    }
}