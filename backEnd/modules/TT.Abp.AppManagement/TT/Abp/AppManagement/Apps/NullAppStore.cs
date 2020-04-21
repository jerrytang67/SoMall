using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;

namespace TT.Abp.AppManagement.Apps
{
    [Dependency(TryRegister = true)]
    public class NullAppStore : IAppStore, ISingletonDependency
    {
        public ILogger<NullAppStore> Logger { get; set; }

        public NullAppStore()
        {
            Logger = NullLogger<NullAppStore>.Instance;
        }

        public Task<Dictionary<string, string>> GetOrNullAsync(string name, string providerName, string providerKey)
        {
            return Task.FromResult(new Dictionary<string, string>());
        }
    }
}