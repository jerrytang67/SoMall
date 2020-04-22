using Microsoft.Extensions.DependencyInjection;
using TT.Abp.Cms.EntityFrameworkCore;
using TT.Abp.Weixin;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.Cms
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpHttpClientModule)
    )]
    public class CmsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CmsDbContext>(options => { options.AddDefaultRepositories(); });

            context.Services.AddAutoMapperObjectMapper<CmsModule>();

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<CmsApplicationAutoMapperProfile>(validate: false); });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(CmsModule).Assembly
                    , opts => { opts.RootPath = "cms"; });
            });

            //创建动态客户端代理
            context.Services.AddHttpClientProxies(typeof(WeixinModule).Assembly);
        }
    }
}