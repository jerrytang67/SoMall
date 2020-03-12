using Microsoft.Extensions.DependencyInjection;
using TT.Abp.ShopManagement;
using TT.Abp.ShopManagement.Application;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace TT.Abp.OssManagement
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class OssManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<OssManagementModule>();

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<OssApplicationAutoMapperProfile>(validate: true); });

            Configure<AbpAspNetCoreMvcOptions>(options => { options.ConventionalControllers.Create(typeof(OssManagementModule).Assembly); });

            
            // Configure<AbpSettingOptions>(options =>
            // {
            //     options.ValueProviders.Add<OssManagementSettingDefinitionProvider>();
            // });
        }

        // public override void PreConfigureServices(ServiceConfigurationContext context)
        // {
        //     PreConfigure<IMvcBuilder>(mvcBuilder => { mvcBuilder.AddApplicationPartIfNotExists(typeof(OssManagementModule).Assembly); });
        // }
    }
}