using Microsoft.Extensions.DependencyInjection;
using TT.Abp.Mall.EntityFrameworkCore;
using TT.Abp.Shops;
using TT.Abp.Weixin;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.Mall
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpHttpClientModule),
        typeof(WeixinModule)
    )]
    public class MallModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MallDbContext>(options => { options.AddDefaultRepositories(true); });

            context.Services.AddAutoMapperObjectMapper<MallModule>();

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<MallApplicationAutoMapperProfile>(validate: false); });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(MallModule).Assembly
                    , opts => { opts.RootPath = "mall"; });
            });

            context.Services.AddTransient<IExternalShopLookupServiceProvider, DefaultShopLookupServiceProvider>();
            
            //创建动态客户端代理
            context.Services.AddHttpClientProxies(typeof(WeixinModule).Assembly);
        }
    }
}