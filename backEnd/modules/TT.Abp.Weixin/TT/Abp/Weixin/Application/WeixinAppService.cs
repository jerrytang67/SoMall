using System;
using System.Net.Http;
using System.Threading.Tasks;
using DotNetCore.CAP;
using IdentityModel.Client;
using IdentityServer4.Configuration;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TT.Abp.Weixin.Application.Dtos;
using TT.Abp.Weixin.Domain;
using TT.Extensions;
using TT.HttpClient.Weixin.Helpers;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;
using Volo.Abp.Uow;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace TT.Abp.Weixin.Application
{
    public class WeixinAppService : ApplicationService, IWeixinAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly ICurrentTenant _currentTenant;
        private readonly ISettingProvider _setting;
        private readonly WeixinManager _weixinManager;
        private readonly IdentityUserStore _identityUserStore;
        private readonly ICapPublisher _capBus;
        private readonly IUserClaimsPrincipalFactory<IdentityUser> _principalFactory;
        private readonly IdentityServerOptions _options;
        private readonly ITokenService _ts;
        private readonly IUnitOfWorkManager _unitOfWorkManager;


        public WeixinAppService(
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            IPasswordHasher<IdentityUser> passwordHasher,
            ICurrentTenant currentTenant,
            ISettingProvider setting,
            WeixinManager weixinManager,
            IdentityUserStore identityUserStore,
            ICapPublisher capBus,
            IUserClaimsPrincipalFactory<IdentityUser> principalFactory,
            IdentityServerOptions options,
            ITokenService TS,
            IUnitOfWorkManager unitOfWorkManager
        )
        {
            ObjectMapperContext = typeof(WeixinModule);
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _passwordHasher = passwordHasher;
            _currentTenant = currentTenant;
            _setting = setting;
            _weixinManager = weixinManager;
            _identityUserStore = identityUserStore;
            _capBus = capBus;
            _principalFactory = principalFactory;
            _options = options;
            _ts = TS;
            _unitOfWorkManager = unitOfWorkManager;
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
        [UnitOfWork(IsDisabled = false)]
        public async Task<object> MiniAuth(WeChatMiniProgramAuthenticateModel loginModel, string appid = null, string appSec = null)
        {
            if (appid.IsNullOrEmpty())
            {
                appid = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppId);
            }

            if (appSec.IsNullOrEmpty())
            {
                appSec = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppSecret);
            }

            var session = await _weixinManager.Mini_Code2Session(loginModel.code, appid, appSec);

            // 解密用户信息
            var miniUserInfo =
                await _weixinManager.Mini_GetUserInfo(appid, loginModel.encryptedData, session.session_key, loginModel.iv);

            // 更新数据库
            await _capBus.PublishAsync("weixin.services.mini.getuserinfo", miniUserInfo);
            var token = "";

            var user = await _identityUserStore.FindByLoginAsync($"unionid", miniUserInfo.unionid);
            if (user == null)
            {
                var userId = Guid.NewGuid();
                user = new IdentityUser(userId, miniUserInfo.unionid, $"{miniUserInfo.unionid}@somall.top", _currentTenant.Id)
                {
                    Name = miniUserInfo.nickName
                };

                using (var uow = _unitOfWorkManager.Begin(requiresNew: true))
                {
                    var passHash = _passwordHasher.HashPassword(user, "1q2w3E*");
                    await _identityUserStore.CreateAsync(user);
                    await _identityUserStore.SetPasswordHashAsync(user, passHash);
                    await _identityUserStore.AddLoginAsync(user, new UserLoginInfo($"unionid", miniUserInfo.unionid, "unionid"));
                    await _identityUserStore.AddLoginAsync(user, new UserLoginInfo($"{appid}_openid", miniUserInfo.openid, "openid"));

                    await _unitOfWorkManager.Current.SaveChangesAsync();
                    await uow.CompleteAsync();
                }
            }

            var serverClient = _httpClientFactory.CreateClient();

            var disco = await serverClient.GetDiscoveryDocumentAsync(_configuration["AuthServer:Authority"]);

            var result = await serverClient.RequestTokenAsync(
                new TokenRequest
                {
                    Address = disco.TokenEndpoint,
                    GrantType = "UserWithTenant",

                    ClientId = _configuration["AuthServer:ClientId"],
                    ClientSecret = _configuration["AuthServer:ClientSecret"],
                    Parameters =
                    {
                        {"user_id", $"{user.Id}"},
                        {"tenantid", $"{user.TenantId}"},
                        {
                            "scope", "SoMall"
                        }
                    }
                });
            token = result.AccessToken;

            return await Task.FromResult(new
            {
                AccessToken = token,
                ExternalUser = miniUserInfo,
                SessionKey = session.session_key
            });
        }


        [HttpGet]
        [Authorize]
        public async Task<object> CheckLogin(bool? dbCheck = false)
        {
            if (!dbCheck.HasValue)
            {
                return await Task.FromResult("ok");
            }

            return await Task.FromResult(CurrentUser);
        }


        [HttpGet]
        [Authorize]
        public async Task<object> GetUnLimitQr(Guid scene, string page = null)
        {
            var shorter = scene.ToShortString();
            return new {url = await _weixinManager.Getwxacodeunlimit(shorter, page)};
        }

        public async Task<object> GetPhone([FromBody] WeChatMiniProgramAuthenticateModel data)
        {
            var json = Encryption.AES_decrypt(data.encryptedData, data.session_key, data.iv);
            return await Task.FromResult(json);
        }
    }
}