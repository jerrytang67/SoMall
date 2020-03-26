using Microsoft.Extensions.DependencyInjection;
using TT.Abp.Shops.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.Shops
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class ShopModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ShopDbContext>(options => { options.AddDefaultRepositories(); });

            context.Services.AddAutoMapperObjectMapper<ShopModule>();

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<ShopApplicationAutoMapperProfile>(validate: true); });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(ShopModule).Assembly);
            });

            //创建动态客户端代理
            context.Services.AddHttpClientProxies(typeof(ShopModule).Assembly);
        }
    }
}