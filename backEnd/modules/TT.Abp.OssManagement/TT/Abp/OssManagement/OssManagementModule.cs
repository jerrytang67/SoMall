using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

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
            
        }

    }
}