using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Serilog;
using TT.Abp.OssManagement;
using TT.Abp.Shops.Application;
using TT.Abp.Weixin.Application;
using TT.Extensions;
using TT.HttpClient.Weixin;
using TT.HttpClient.Weixin.Helpers;
using TT.HttpClient.Weixin.WeixiinResult;
using TT.Oss;
using TT.Redis;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;
using Volo.Abp.Uow;

namespace TT.Abp.Weixin.Domain
{
    public class WeixinManager : ITransientDependency
    {
        private readonly IDistributedCache<AccessTokeCacheItem> _tokenCache;
        private readonly IRedisClient _redisClient;
        private readonly IRepository<WechatUserinfo> _wechatUserRepository;
        private readonly Volo.Abp.ObjectMapping.IObjectMapper _mapper;
        private readonly ICurrentTenant _currentTenant;
        private readonly ISettingProvider _setting;
        private readonly IWeixinApi _weixinApi;

        public WeixinManager(
            IDistributedCache<AccessTokeCacheItem> tokenCache,
            IRedisClient redisClient,
            IRepository<WechatUserinfo> wechatUserRepository,
            Volo.Abp.ObjectMapping.IObjectMapper mapper,
            ICurrentTenant currentTenant,
            ISettingProvider setting,
            IWeixinApi weixinApi)
        {
            _tokenCache = tokenCache;
            _redisClient = redisClient;
            _wechatUserRepository = wechatUserRepository;
            _mapper = mapper;
            _currentTenant = currentTenant;
            _setting = setting;
            _weixinApi = weixinApi;
        }


        [UnitOfWork]
        public virtual async Task CreateOrUpdate(MiniUserInfoResult userinfo)
        {
            var find = await _wechatUserRepository.FirstOrDefaultAsync(x => x.appid == userinfo.appid && x.openid == userinfo.openid);
            if (find == null)
            {
                await _wechatUserRepository.InsertAsync(
                    new WechatUserinfo(userinfo.appid, userinfo.openid, userinfo.unionid, userinfo.nickName, userinfo.avatarUrl, appName: userinfo.AppName)
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
            var session = await _weixinApi.Mini_Code2Session(code, appid, appsecret);

            if (session == null)
            {
                throw new UserFriendlyException("解密失败");
            }

            return session;
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

        public async Task<MiniUserInfoResult> Mini_GetUserInfo(string appid, string encryptedDataStr, string sessionKey, string iv)
        {
            var json = Encryption.AES_decrypt(encryptedDataStr, sessionKey, iv);

            var userInfo = JsonConvert.DeserializeObject<MiniUserInfoResult>(json);
#if DEBUG
            Log.Logger.Debug(JsonConvert.SerializeObject(userInfo));
#endif
            userInfo.appid = appid;

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

        public virtual async Task<string> Getwxacodeunlimit(string scene, string page = "pages/index/index")
        {
            var key = "SoMall:QR:Mini";
            var cache = await _redisClient.Database.HashGetAsync(key, scene);

            if (cache.HasValue)
            {
                return cache.ToString();
            }

            var appId = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppId);
            var appSec = await _setting.GetOrNullAsync(WeixinManagementSetting.MiniAppSecret);

            var token = await GetAccessTokenAsync(appId, appSec);

            var url = $"https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token={token}";
            var img = HttpEx.PostGotImageByte(url, new {scene, page});
            var upyun = await GetUploader();
            var result = upyun.writeFile($"/somall/mini_qr/{scene}.jpg", img,
                true);
            if (result)
            {
                var path = $"{upyun.Domain}/somall/mini_qr/{scene}.jpg";
                await _redisClient.Database.HashSetAsync(key, scene,
                    path);
                return path;
            }

            throw new UserFriendlyException("生成小程序二维码失败");
        }

        private async Task<UpYun> GetUploader()
        {
            var bucketName = await _setting.GetOrNullAsync(OssManagementSettings.BucketName);
            var domain = await _setting.GetOrNullAsync(OssManagementSettings.DomainHost);
            var pwd = await _setting.GetOrNullAsync(OssManagementSettings.AccessKey);
            var username = await _setting.GetOrNullAsync(OssManagementSettings.AccessId);
            return new UpYun(bucketName, username,
                pwd, domain);
        }
    }


    public class WexinCapSubscriberService : ICapSubscribe, IScopedDependency
    {
        private readonly WeixinManager _weixinManager;

        public WexinCapSubscriberService(WeixinManager weixinManager)
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