using System.Collections.Generic;
using System.Threading.Tasks;

namespace TT.Abp.AppManagement.Apps
{
    public class DefaultValueAppValueProvider : AppValueProvider
    {
        public const string ProviderName = "D";

        public override string Name => ProviderName;

        
        public DefaultValueAppValueProvider(IAppStore settingStore)
            : base(settingStore)
        {
        }
        
        public override Task<Dictionary<string, string>> GetOrNullAsync(AppDefinition app)
        {
            return Task.FromResult(app.DefaultValues);
        }

    }
}