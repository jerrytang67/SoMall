using System.Collections.Generic;
using System.Threading.Tasks;

namespace TT.Abp.AppManagement.Apps
{
    public class GlobalAppValueProvider : AppValueProvider
    {
        public const string ProviderName = "G";

        public GlobalAppValueProvider(IAppStore settingStore)
            : base(settingStore)
        {
        }

        public override string Name => ProviderName;

        public override Task<Dictionary<string, string>> GetOrNullAsync(AppDefinition setting)
        {
            return AppStore.GetOrNullAsync(setting.Name, Name, null);
        }
    }
}