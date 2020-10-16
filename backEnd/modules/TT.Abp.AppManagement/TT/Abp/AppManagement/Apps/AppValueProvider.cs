using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TT.Abp.AppManagement.Apps
{
    public abstract class AppValueProvider : IAppValueProvider, ITransientDependency
    {
        protected AppValueProvider(IAppStore appStore)
        {
            AppStore = appStore;
        }

        protected IAppStore AppStore { get; }
        public abstract string Name { get; }

        public abstract Task<Dictionary<string, string>> GetOrNullAsync(AppDefinition app);
    }
}