using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace TT.Extensions.Redis
{
    public interface IRedisClient
    {
        IDatabase Database { get; }
    }

    public class RedisClient : IRedisClient
    {
        public IDatabase Database { get; }

        public RedisClient(IOptionsSnapshot<RedisOptions> optionsAccessor)
        {
            Database = ConnectionMultiplexer.Connect(optionsAccessor.Value.ConnectionString).GetDatabase(optionsAccessor.Value.DatabaseId);
        }
    }

    public class RedisOptions
    {
        public string ConnectionString { get; set; } = "127.0.0.1,connectTimeout=1000,syncTimeout=1000";
        public int DatabaseId { get; set; } = -1;
    }
}