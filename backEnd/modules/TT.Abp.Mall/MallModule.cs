using EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.Shops;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.Mall
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class MallModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MallDbContext>(options => { options.AddDefaultRepositories(); });

            context.Services.AddAutoMapperObjectMapper<MallModule>();

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<MallApplicationAutoMapperProfile>(validate: false); });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(MallModule).Assembly
                    , opts => { opts.RootPath = "mall"; });
            });

            context.Services.AddTransient<IExternalShopLookupServiceProvider, DefaultShopLookupServiceProvider>();
        }
    }
}