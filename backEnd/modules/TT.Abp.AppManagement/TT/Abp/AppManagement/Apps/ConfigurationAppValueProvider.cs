using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace TT.Abp.AppManagement.Apps
{
    public class ConfigurationAppValueProvider : IAppValueProvider, ITransientDependency
    {
        public const string ConfigurationNamePrefix = "Apps:";

        public const string ProviderName = "C";

        public string Name => ProviderName;

        protected IConfiguration Configuration { get; }

        public ConfigurationAppValueProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public virtual Task<Dictionary<string, string>> GetOrNullAsync(AppDefinition setting)
        {
            var result = new Dictionary<string, string>();
            var section = Configuration.GetSection(ConfigurationNamePrefix + setting.Name).GetChildren();

            if (section == null || !section.Any())
            {
                return Task.FromResult<Dictionary<string, string>>(null);
            }

            foreach (var v in section)
            {
                result[v.Key] = v.Value;
            }

            return Task.FromResult(result);
        }
    }
}