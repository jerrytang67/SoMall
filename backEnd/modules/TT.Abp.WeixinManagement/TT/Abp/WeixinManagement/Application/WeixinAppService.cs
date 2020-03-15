using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DotNetCore.CAP;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Serilog;
using TT.Abp.WeixinManagement.Application.Dtos;
using TT.Abp.WeixinManagement.Domain;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Settings;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace TT.Abp.WeixinManagement.Application
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
        private readonly IdentityUserStore _identityUserStore;
        private readonly ICapPublisher _capBus;
        private readonly IUserClaimsPrincipalFactory<IdentityUser> _principalFactory;
        private readonly IdentityServerOptions _options;
        private readonly ITokenService _ts;


        public WeixinAppService(ICurrentTenant currentTenant,
            ISettingProvider setting,
            WeixinManager weixinManager,
            IdentityUserStore identityUserStore,
            ICapPublisher capBus,
            IUserClaimsPrincipalFactory<IdentityUser> principalFactory,
            IdentityServerOptions options,
            ITokenService TS
        )
        {
            ObjectMapperContext = typeof(WeixinManagementModule);
            _currentTenant = currentTenant;
            _setting = setting;
            _weixinManager = weixinManager;
            _identityUserStore = identityUserStore;
            _capBus = capBus;
            _principalFactory = principalFactory;
            _options = options;
            _ts = TS;
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
            var appId = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppId);
            var appSec = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppSecret);

            var session = await _weixinManager.Mini_Code2Session(loginModel.code, appId, appSec);

            // 解密用户信息
            var miniUserInfo =
                await _weixinManager.Mini_GetUserInfo(appId, loginModel.encryptedData, session.session_key, loginModel.iv);

            // 更新数据库
            await _capBus.PublishAsync("weixin.services.mini.getuserinfo", miniUserInfo);

            var user = await _identityUserStore.FindByLoginAsync(appId, miniUserInfo.openid);
            if (user == null)
            {
                var userId = Guid.NewGuid();
                user = new IdentityUser(userId, miniUserInfo.nickName, $"{miniUserInfo.unionid}@somall.top", _currentTenant.Id);

                await _identityUserStore.CreateAsync(user);
                await _identityUserStore.AddLoginAsync(user, new UserLoginInfo(appId, miniUserInfo.openid, "openid"));
                //await _identityUserStore.AddLoginAsync(user, new UserLoginInfo("appId", miniUserInfo.unionid, "unionid"));
            }

            var token = await LoginAs(user);

            return await Task.FromResult(new
            {
                AccessToken = token,
                ExternalUser = miniUserInfo,
                SessionKey = session.session_key
            });
        }


        public async Task<string> LoginAs(IdentityUser user)
        {
            var Request = new TokenCreationRequest();
            var IdentityPricipal = await _principalFactory.CreateAsync(user);
            var IdentityUser = new IdentityServerUser(user.Id.ToString());
            IdentityUser.AdditionalClaims = IdentityPricipal.Claims.ToArray();
            IdentityUser.DisplayName = user.UserName;
            IdentityUser.AuthenticationTime = System.DateTime.UtcNow;
            IdentityUser.IdentityProvider = IdentityServerConstants.LocalIdentityProvider;
            Request.Subject = IdentityUser.CreatePrincipal();
            Request.IncludeAllIdentityClaims = true;
            Request.ValidatedRequest = new ValidatedRequest();
            Request.ValidatedRequest.Subject = Request.Subject;
            Request.ValidatedRequest.SetClient(GetClient());
            Request.Resources = new Resources(GetIdentityResources(), GetApiResources());
            Request.ValidatedRequest.Options = _options;
            Request.ValidatedRequest.ClientClaims = IdentityUser.AdditionalClaims;
            var Token = await _ts.CreateAccessTokenAsync(Request);
            //Token.Issuer = "http://localhost:44340";
            var TokenValue = await _ts.CreateSecurityTokenAsync(Token);
            return TokenValue;
        }


        public static Client GetClient()
        {
            return new Client
            {
                ClientId = "SoMall_App",
                ClientSecrets = {new Secret("1q2w3e*".Sha256())},
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedScopes = {"SoMall"},
                AllowOfflineAccess = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AlwaysSendClientClaims = true
            };
        }


        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResource
                {
                    Name = "role",
                    DisplayName = "Role",
                    UserClaims = new[] {JwtClaimTypes.Role, ClaimTypes.Role},
                    ShowInDiscoveryDocument = true,
                    Required = true,
                    Emphasize = true
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("SoMall", "SoMall"),
            };
        }
    }
}