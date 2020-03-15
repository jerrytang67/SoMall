using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using TT.Abp.ShopManagement.Application.Dtos;
using TT.Abp.WeixinManagement;
using TT.Abp.WeixinManagement.Domain;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;

namespace TT.Abp.ShopManagement.Application
{
    public interface IWeixinAppService : IApplicationService
    {
        Task<string> GetAccessToken(string appid);
    }

    public class WeixinAppService : ApplicationService, IWeixinAppService
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly ISettingProvider _setting;
        private readonly WeixinManager _weixinManager;
        private readonly ICapPublisher _capBus;
        

        public WeixinAppService(ICurrentTenant currentTenant,
            ISettingProvider setting,
            WeixinManager weixinManager,
            ICapPublisher capBus)
        {
            ObjectMapperContext = typeof(WeixinManagementModule);
            _currentTenant = currentTenant;
            _setting = setting;
            _weixinManager = weixinManager;
            _capBus = capBus;
        }

        public async Task<object> Code2Session(WeChatMiniProgramAuthenticateModel loginModel)
        {
            return await Task.FromResult<object>(null);
        }


        public async Task<string> GetAccessToken(string appid)
        {
            var appId = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppId);
            var appSec = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppSecret);

            var token = await _weixinManager.GetAccessTokenAsync(appId, appSec);

            return token;
        }

        [HttpPost]
        public async Task<object> MiniAuth(WeChatMiniProgramAuthenticateModel loginModel)
        {
            var provider = "WeChatMiniProgram";
            var appId = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppId);
            var appSec = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppSecret);

            var session = await _weixinManager.Mini_Code2Session(loginModel.code, appId, appSec);

            if (session == null)
            {
                throw new UserFriendlyException("解密失败");
            }

            // 解密用户信息
            var miniUserInfo =
                await _weixinManager.Mini_GetUserInfo(loginModel.encryptedData, session.session_key, loginModel.iv);

            miniUserInfo.appid = appId;

            await _capBus.PublishAsync("weixin.services.mini.getuserinfo", miniUserInfo);

            return await Task.FromResult(new
            {
                AccessToken = "123",
                ExternalUser = miniUserInfo,
                SessionKey = session.session_key
            });
        }
    }
}