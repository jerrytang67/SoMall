using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.WeixinManagement
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class WeixinManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<WeixinManagementModule>();

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<WeixinApplicationAutoMapperProfile>(validate: true); });

            Configure<AbpAspNetCoreMvcOptions>(options => { options.ConventionalControllers.Create(typeof(WeixinManagementModule).Assembly); });

            //创建动态客户端代理
            context.Services.AddHttpClientProxies(typeof(WeixinManagementModule).Assembly);
        }
    }
}