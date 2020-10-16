using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TT.Abp.AppManagement.Apps
{
    public class AppStore : IAppStore, ITransientDependency
    {
        public AppStore(IAppManagementStore managementStore)
        {
            ManagementStore = managementStore;
        }

        protected IAppManagementStore ManagementStore { get; }

        public Task<Dictionary<string, string>> GetOrNullAsync(string name, string providerName, string providerKey)
        {
            return ManagementStore.GetOrNullAsync(name, providerName, providerKey);
        }
    }

    public interface IAppManagementStore
    {
        Task<Dictionary<string, string>> GetOrNullAsync(string name, string providerName, string providerKey);

        Task<List<AppValue>> GetListAsync(string providerName, string providerKey);

        Task SetAsync(string name, string clientName, Dictionary<string, string> value, string providerName, string providerKey);

        Task DeleteAsync(string name, string providerName, string providerKey);
    }
}