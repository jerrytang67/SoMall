using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.DependencyInjection;

namespace TT.Abp.AppManagement.Apps
{
    public interface IAppValueProvider
    {
        string Name { get; }

        Task<string> GetOrNullAsync([NotNull] AppDefinition setting);

        Task<string> GetOrNullAsync([NotNull] string name);

        Task<List<AppValue>> GetAllAsync();
    }


    public interface IAppDefinitionManager
    {
        [NotNull]
        AppDefinition Get([NotNull] string name);

        IReadOnlyList<AppDefinition> GetAll();

        AppDefinition GetOrNull(string name);
    }

    public interface IAppValueProviderManager
    {
        List<IAppValueProvider> Providers { get; }
    }

    public abstract class AppValueProvider : IAppValueProvider, ITransientDependency
    {
        protected IAppDefinitionManager AppDefinitionManager { get; }
        protected IAppValueProviderManager AppValueProviderManager { get; }

        protected AppValueProvider(
            IAppDefinitionManager appDefinitionManager,
            IAppValueProviderManager appValueProviderManager
        )
        {
            AppDefinitionManager = appDefinitionManager;
            AppValueProviderManager = appValueProviderManager;
        }

        public string Name { get; }

        public Task<string> GetOrNullAsync(AppDefinition setting)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetOrNullAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<AppValue>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}