using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.ShopManagement
{
    [DependsOn(typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class ShopManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ShopManagementModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ShopApplicationAutoMapperProfile>(validate: true);
            });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(ShopManagementModule).Assembly);
            });

            //创建动态客户端代理
            // context.Services.AddHttpClientProxies(typeof(ShopManagementModule).Assembly);
        }


        // public override void PreConfigureServices(ServiceConfigurationContext context)
        // {
        //     PreConfigure<IMvcBuilder>(mvcBuilder =>
        //     {
        //         mvcBuilder.AddApplicationPartIfNotExists(typeof(ShopManagementModule).Assembly);
        //     });
        // }

    }
}