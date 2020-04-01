using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using TT.Extensions;

namespace TT.HttpClient.Weixin
{
    public interface IRedisClient
    {
        Task<bool> HashSetAsync(string key, RedisValue hashKey, RedisValue value, When when = When.Always);

        Task<RedisValue> HashGetAsync(string key, RedisValue hashKey);

        Task<bool> HashDeleteAsync(string key, RedisValue hashKey);
    }

    public class RedisClient : IRedisClient, IDisposable
    {
        private readonly RedisOptions _options;

        private readonly IDatabase _redis;

        public RedisClient(IOptionsSnapshot<RedisOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
            _redis = ConnectionMultiplexer.Connect(_options.ConnectionString).GetDatabase(_options.DatabaseId);
        }

        public async Task<bool> HashSetAsync(string key, RedisValue hashKey, RedisValue value, When when = When.Always)
        {
            return await _redis.HashSetAsync(key, hashKey, value, when);
        }

        public async Task<RedisValue> HashGetAsync(string key, RedisValue hashKey)
        {
            if (!key.IsNullOrEmptyOrWhiteSpace() && hashKey.HasValue)
                return await _redis.HashGetAsync(key, hashKey);
            return RedisValue.Null;
        }

        public async Task<bool> HashDeleteAsync(string key, RedisValue hashKey)
        {
            return await _redis.HashDeleteAsync(key, hashKey);
        }

        public void Dispose()
        {
        }
    }

    public class RedisOptions
    {
        public string ConnectionString { get; set; } = "127.0.0.1,connectTimeout=1000,syncTimeout=1000";

        public int DatabaseId { get; set; } = -1;
    }

    public class AppOptions
    {
        public string ServerRootAddress { get; set; }

        public string ClientRootAddress { get; set; }
    }
}