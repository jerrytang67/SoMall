using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TT.Abp.ShopManagement.Application.Dtos;
using TT.Abp.WeixinManagement;
using TT.Abp.WeixinManagement.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;

namespace TT.Abp.ShopManagement.Application
{
    public interface IWeixinAppService :IApplicationService
    {
        Task<string> GetAccessToken(string appid);
    }

    public class WeixinAppService : ApplicationService, IWeixinAppService
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly ISettingProvider _setting;
        private readonly WeixinService _weixinService;

        public WeixinAppService(ICurrentTenant currentTenant,
            ISettingProvider setting,
            WeixinService weixinService)
        {
            ObjectMapperContext = typeof(WeixinManagementModule);
            _currentTenant = currentTenant;
            _setting = setting;
            _weixinService = weixinService;
        }

        public async Task<object> Code2Session(WeChatMiniProgramAuthenticateModel loginModel)
        {
            return await Task.FromResult<object>(null);
        }


        public async Task<string> GetAccessToken(string appid)
        {
            var appId = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppId);
            var appSec = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppSecret);
            
            var token = await _weixinService.GetAccessTokenAsync(appId, appSec);

            return token;
        }
    }
}