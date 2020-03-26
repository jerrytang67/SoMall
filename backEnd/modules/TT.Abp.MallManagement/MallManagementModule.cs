using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.MallManagement
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class MallManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MallManagementModule>();

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<MallApplicationAutoMapperProfile>(validate: false); });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(MallManagementModule).Assembly);
            });
        }
    }
}