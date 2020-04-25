using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Settings;

namespace TT.Abp.AppManagement.Apps
{
    public class AppDefinitionManager : IAppDefinitionManager, ISingletonDependency
    {
        protected Lazy<IDictionary<string, AppDefinition>> AppDefinitions { get; }

        protected AppOptions Options { get; }

        protected IServiceProvider ServiceProvider { get; }

        public AppDefinitionManager(
            IOptions<AppOptions> options, IServiceProvider serviceProvider)
        {
            Options = options.Value;
            ServiceProvider = serviceProvider;

            AppDefinitions = new Lazy<IDictionary<string, AppDefinition>>(CreateSettingDefinitions, true);
        }

        public AppDefinition Get(string name)
        {
            Check.NotNull(name, nameof(name));
            
            var app = GetOrNull(name);
            
            if (app == null)
            {
                throw new AbpException("Undefined setting: " + name);
            }
            
            return app;
        }

        public IReadOnlyList<AppDefinition> GetAll()
        {
            return AppDefinitions.Value.Values.ToImmutableList();
        }

        public AppDefinition GetOrNull(string name)
        {
            return AppDefinitions.Value.GetOrDefault(name);
        }

        protected virtual IDictionary<string, AppDefinition> CreateSettingDefinitions()
        {
            var apps = new Dictionary<string, AppDefinition>();

            using (var scope = ServiceProvider.CreateScope())
            {
                var providers = Options
                    .DefinitionProviders
                    .Select(p => scope.ServiceProvider.GetRequiredService(p) as IAppDefinitionProvider)
                    .ToList();

                foreach (var provider in providers)
                {
                    provider.Define(new AppDefinitionContext(apps));
                }
            }

            return apps;
        }
    }
}