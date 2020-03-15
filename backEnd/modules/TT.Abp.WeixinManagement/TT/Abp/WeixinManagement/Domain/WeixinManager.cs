using System;
using System.Threading.Tasks;
using AutoMapper;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Serilog;
using TT.HttpClient.Weixin;
using TT.HttpClient.Weixin.Helpers;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.WeixinManagement.Domain
{
    public class WeixinManager : ITransientDependency
    {
        private readonly IDistributedCache<AccessTokeCacheItem> _tokenCache;
        private readonly IRepository<WechatUserinfo> _wechatUserRepository;
        private readonly Volo.Abp.ObjectMapping.IObjectMapper _mapper;
        private readonly IWeixinApi _weixinApi;

        public WeixinManager(
            IDistributedCache<AccessTokeCacheItem> tokenCache,
            IRepository<WechatUserinfo> wechatUserRepository,
            Volo.Abp.ObjectMapping.IObjectMapper mapper,
            IWeixinApi weixinApi)
        {
            _tokenCache = tokenCache;
            _wechatUserRepository = wechatUserRepository;
            _mapper = mapper;
            _weixinApi = weixinApi;
        }


        [UnitOfWork]
        public virtual async Task CreateOrUpdate(MiniUserInfoResult userinfo)
        {
            var find = await _wechatUserRepository.FirstOrDefaultAsync(x => x.appid == userinfo.appid && x.openid == userinfo.openid);
            if (find == null)
            {
                await _wechatUserRepository.InsertAsync(
                    new WechatUserinfo(userinfo.appid, userinfo.openid, userinfo.unionid, userinfo.nickName, userinfo.avatarUrl, WeixinEnums.ClientType.Mini)
                    {
                        city = userinfo.city,
                        province = userinfo.province,
                        sex = userinfo.gender,
                        country = userinfo.country
                    });
            }
            else
            {
                _mapper.Map(userinfo, find);
            }
        }


        public async Task<MiniSessionResult> Mini_Code2Session(string code, string appid, string appsecret)
        {
            return await _weixinApi.Mini_Code2Session(code, appid, appsecret);
        }

        public async Task<string> GetAccessTokenAsync(string appid, string appSeret)
        {
            var cache = await _tokenCache.GetOrAddAsync(
                appid, //Cache key
                async () => await GetAccessToken(appid, appSeret),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                }
            );
            if (cache != null)
            {
                if (cache.TimeExpired <= DateTimeOffset.Now)
                {
                    await _tokenCache.RemoveAsync(appid);
                    cache = await _tokenCache.GetOrAddAsync(
                        appid, //Cache key
                        async () => await GetAccessToken(appid, appSeret),
                        () => new DistributedCacheEntryOptions
                        {
                            AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                        }
                    );
                }

                return cache.AccessToken;
            }

            throw new UserFriendlyException("token 获取失败");
        }

        public async Task<MiniUserInfoResult> Mini_GetUserInfo(string encryptedDataStr, string sessionKey, string iv)
        {
            var json = Encryption.AES_decrypt(encryptedDataStr, sessionKey, iv);

            var userInfo = JsonConvert.DeserializeObject<MiniUserInfoResult>(json);
#if DEBUG
            Log.Logger.Debug(JsonConvert.SerializeObject(userInfo));
#endif


            return await Task.FromResult(userInfo);
        }

        private async Task<AccessTokeCacheItem> GetAccessToken(string appid, string appSeret)
        {
            var token = await _weixinApi.GetToken(appid, appSeret);
            if (token.errcode == 0)
            {
                Log.Logger.Information(JsonConvert.SerializeObject(token));
                return new AccessTokeCacheItem()
                {
                    Appid = appid,
                    AppSecret = appSeret,
                    AccessToken = token.access_token,
                    TimeCreated = DateTimeOffset.Now,
                    TimeExpired = DateTimeOffset.Now.AddSeconds(token.expires_in)
                };
            }

            Log.Logger.Error($"token 获取失败: {token.errmsg}");
            Log.Logger.Error(JsonConvert.SerializeObject(token));
            return null;
        }
    }


    public class SubscriberService : ICapSubscribe
    {
        private readonly WeixinManager _weixinManager;

        public SubscriberService(WeixinManager weixinManager)
        {
            _weixinManager = weixinManager;
        }

        [CapSubscribe("weixin.services.mini.getuserinfo")]
        public async Task Subscriber(MiniUserInfoResult userInfo)
        {
            Log.Logger.Warning("Cap");
            Log.Logger.Warning(JsonConvert.SerializeObject(userInfo));
            await _weixinManager.CreateOrUpdate(userInfo);
        }
    }
}