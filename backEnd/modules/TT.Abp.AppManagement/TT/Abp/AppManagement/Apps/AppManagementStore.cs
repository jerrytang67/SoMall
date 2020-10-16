using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TT.Abp.AppManagement.Domain;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace TT.Abp.AppManagement.Apps
{
    public class AppManagementStore : IAppManagementStore, ITransientDependency
    {
        public AppManagementStore(
            IAppRepository appRepository,
            IGuidGenerator guidGenerator,
            IDistributedCache<AppCacheItem> cache)
        {
            AppRepository = appRepository;
            GuidGenerator = guidGenerator;
            Cache = cache;
        }

        protected IDistributedCache<AppCacheItem> Cache { get; }
        protected IAppRepository AppRepository { get; }
        protected IGuidGenerator GuidGenerator { get; }

        public virtual async Task<Dictionary<string, string>> GetOrNullAsync(string name, string providerName, string providerKey)
        {
            var cacheItem = await GetCacheItemAsync(name, providerName, providerKey);
            return cacheItem.Value;
        }

        public virtual async Task SetAsync(string name, string clientName, Dictionary<string, string> value, string providerName, string providerKey)
        {
            var setting = await AppRepository.FindAsync(name, providerName, providerKey);
            if (setting == null)
            {
                setting = new App(GuidGenerator.Create(), name, clientName, value, providerName, providerKey);
                await AppRepository.InsertAsync(setting);
            }
            else
            {
                setting.Value = value;
                await AppRepository.UpdateAsync(setting);
                var cacheKey = CalculateCacheKey(name, providerName, providerKey);
                await Cache.RemoveAsync(
                    cacheKey
                );
            }
        }

        public virtual async Task<List<AppValue>> GetListAsync(string providerName, string providerKey)
        {
            var apps = await AppRepository.GetListAsync(providerName, providerKey);
            return apps.Select(s => new AppValue(s.Name, s.Value)).ToList();
        }

        public virtual async Task DeleteAsync(string name, string providerName, string providerKey)
        {
            var setting = await AppRepository.FindAsync(name, providerName, providerKey);
            if (setting != null)
            {
                await AppRepository.DeleteAsync(setting);
            }
        }

        protected virtual async Task<AppCacheItem> GetCacheItemAsync(string name, string providerName, string providerKey)
        {
            var cacheKey = CalculateCacheKey(name, providerName, providerKey);
            var cacheItem = await Cache.GetAsync(cacheKey);

            if (cacheItem != null)
            {
                return cacheItem;
            }

            var app = await AppRepository.FindAsync(name, providerName, providerKey);

            cacheItem = new AppCacheItem(app?.Value);

            await Cache.SetAsync(
                cacheKey,
                cacheItem
            );

            return cacheItem;
        }

        protected virtual string CalculateCacheKey(string name, string providerName, string providerKey)
        {
            return AppCacheItem.CalculateCacheKey(name, providerName, providerKey);
        }
    }
}