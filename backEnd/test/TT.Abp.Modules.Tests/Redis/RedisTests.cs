using System.Threading.Tasks;
using Shouldly;
using StackExchange.Redis;
using TT.Extensions.Redis;
using Xunit;

namespace TT.Abp.Modules.Tests.Redis
{
    public class RedisTests : SoMallModulesTestBase
    {
        private readonly IRedisClient _redisClient;

        public RedisTests()
        {
            _redisClient = GetRequiredService<IRedisClient>();
        }


        [Fact]
        public async Task TestHastSet()
        {
            //Act
            await _redisClient.Database.HashSetAsync("test", "key1", "1");
            await _redisClient.Database.HashSetAsync("test", "key2", "2");

            var key1 = await _redisClient.Database.HashGetAsync("test", "key1");
            var key2 = await _redisClient.Database.HashGetAsync("test", "key2");

            key1.ToString().ShouldBe("1");
            key2.ToString().ShouldBe("2");

            // Delete
            await _redisClient.Database.HashDeleteAsync("test", "key1");

            var len = await _redisClient.Database.HashLengthAsync("test");
            len.ShouldBe(1);

            // Clear All
            await _redisClient.Database.KeyDeleteAsync("test");
        }

        [Fact]
        public async Task StreamTest()
        {
            await _redisClient.Database.StreamAddAsync("somall_stream_test", "key:1", new RedisValue("123"));
            await _redisClient.Database.StreamAddAsync("somall_stream_test", "key:2", new RedisValue("456"));
        }
    }
}