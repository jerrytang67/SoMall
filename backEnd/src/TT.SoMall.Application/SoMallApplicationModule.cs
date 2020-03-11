using Microsoft.Extensions.DependencyInjection;
using TT.Abp.ShopManagement;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace TT.SoMall
{
    [DependsOn(
        typeof(SoMallDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(SoMallApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule)
        // typeof(ShopManagementModule)
        )]
    public class SoMallApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<SoMallApplicationModule>();
            });
        }
    }
}
