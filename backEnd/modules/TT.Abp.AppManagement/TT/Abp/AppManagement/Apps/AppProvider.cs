using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Settings;

namespace TT.Abp.AppManagement.Apps
{
    public interface IAppProvider
    {
        Task<Dictionary<string, string>> GetOrNullAsync([NotNull] string name);

        Task<List<AppValue>> GetAllAsync();
    }


    public class AppProvider : IAppProvider, ITransientDependency
    {
        protected IAppDefinitionManager AppDefinitionManager { get; }
        protected IAppValueProviderManager AppValueProviderManager { get; }

        public AppProvider(
            IAppDefinitionManager appDefinitionManager,
            IAppValueProviderManager appValueProviderManager)
        {
            AppDefinitionManager = appDefinitionManager;
            AppValueProviderManager = appValueProviderManager;
        }

        public virtual async Task<Dictionary<string, string>> GetOrNullAsync(string name)
        {
            var apps = AppDefinitionManager.Get(name);

            var providers = Enumerable
                .Reverse(AppValueProviderManager.Providers);

            if (apps.Providers.Any())
            {
                providers = providers.Where(p => apps.Providers.Contains(p.Name));
            }

            //TODO: How to implement setting.IsInherited?

            var value = await GetOrNullValueFromProvidersAsync(providers, apps);
            return value;
        }

        public virtual async Task<List<AppValue>> GetAllAsync()
        {
            var appValues = new Dictionary<string, AppValue>();
            var settingDefinitions = AppDefinitionManager.GetAll();

            foreach (var provider in AppValueProviderManager.Providers)
            {
                foreach (var setting in settingDefinitions)
                {
                    var value = await provider.GetOrNullAsync(setting);
                    if (value != null)
                    {
                        appValues[setting.Name] = new AppValue(setting.Name, value);
                    }
                }
            }

            return appValues.Values.ToList();
        }

        protected virtual async Task<Dictionary<string, string>> GetOrNullValueFromProvidersAsync(
            IEnumerable<IAppValueProvider> providers,
            AppDefinition app)
        {
            foreach (var provider in providers)
            {
                var value = await provider.GetOrNullAsync(app);
                if (value != null)
                {
                    return value;
                }
            }

            return null;
        }
    }
}