using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TT.SoMall.Localization;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc.Conventions;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.TenantManagement;

namespace TT.SoMall
{
    [DependsOn(
        typeof(SoMallApplicationContractsModule),
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpTenantManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule)
    )]
    public class SoMallHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // Configure<AbpConventionalControllerOptions>(options =>
            // {
            //     options.UseV3UrlStyle = true;
            // });
            
            // context.Services.Replace(ServiceDescriptor.Transient<IAbpServiceConvention, TtServiceConvention>());
            // context.Services.Replace(ServiceDescriptor.Transient<IConventionalRouteBuilder, TtConventionalRouteBuilder>());
			         //    ConfigureLocalization();
        }
        private void ConfigureLocalization()
        {
            
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<SoMallResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}