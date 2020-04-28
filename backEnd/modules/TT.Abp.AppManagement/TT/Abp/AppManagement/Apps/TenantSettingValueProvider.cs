using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.AppManagement.Apps
{
    public class TenantAppValueProvider : AppValueProvider
    {
        public const string ProviderName = "T";
        public override string Name => ProviderName;
        protected ICurrentTenant CurrentTenant { get; }


        public TenantAppValueProvider(IAppStore appStore, ICurrentTenant currentTenant)
            : base(appStore)
        {
            CurrentTenant = currentTenant;
        }

        public override async Task<Dictionary<string, string>> GetOrNullAsync(AppDefinition setting)
        {
            return await AppStore.GetOrNullAsync(setting.Name, Name, CurrentTenant.Id?.ToString());
        }
    }
}