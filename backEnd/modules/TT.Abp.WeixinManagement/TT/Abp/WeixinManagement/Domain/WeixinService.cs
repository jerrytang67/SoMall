using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Serilog;
using TT.HttpClient.Weixin;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace TT.Abp.WeixinManagement.Domain
{
    public class AccessTokeCacheItem
    {
        public string AccessToken { get; set; }

        public string Appid { get; set; }

        public string AppSecret { get; set; }

        public DateTimeOffset TimeCreated { get; set; }

        public DateTimeOffset TimeExpired { get; set; }
    }


    public class WeixinService : ITransientDependency
    {
        private readonly IDistributedCache<AccessTokeCacheItem> _tokenCache;
        private readonly IWeixinApi _weixinApi;

        public WeixinService(IDistributedCache<AccessTokeCacheItem> tokenCache,
            IWeixinApi weixinApi)
        {
            _tokenCache = tokenCache;
            _weixinApi = weixinApi;
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
                return cache.AccessToken;
            }

            throw new UserFriendlyException("token 获取失败");
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
                    TimeExpired = DateTimeOffset.Now.AddTicks(token.expires_in)
                };
            }

            Log.Logger.Error($"token 获取失败: {token.errmsg}");
            Log.Logger.Error(JsonConvert.SerializeObject(token));
            return null;
        }
    }
}