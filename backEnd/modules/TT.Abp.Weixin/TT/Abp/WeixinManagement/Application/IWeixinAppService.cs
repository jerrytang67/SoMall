using System;
using System.Threading.Tasks;
using TT.Abp.WeixinManagement.Application.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.WeixinManagement.Application
{
    public interface IWeixinAppService : IApplicationService
    {
        Task<string> GetAccessToken(string appid);
    }
}