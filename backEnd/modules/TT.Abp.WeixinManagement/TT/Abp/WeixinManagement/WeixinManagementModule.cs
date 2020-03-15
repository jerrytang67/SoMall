using System;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.WeixinManagement.EntityFrameworkCore;
using TT.HttpClient.Weixin;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.WeixinManagement
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class WeixinManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<WeixinManagementDbContext>(options => { options.AddDefaultRepositories(); });

            context.Services.AddHttpClient<IWeixinApi, WeixinApi>(
                cfg => { cfg.BaseAddress = new Uri("https://api.weixin.qq.com/"); });

            context.Services.AddAutoMapperObjectMapper<WeixinManagementModule>();

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<WeixinApplicationAutoMapperProfile>(validate: true); });


            Configure<AbpAspNetCoreMvcOptions>(options => { options.ConventionalControllers.Create(typeof(WeixinManagementModule).Assembly); });

            //创建动态客户端代理
            context.Services.AddHttpClientProxies(typeof(WeixinManagementModule).Assembly);
            

            // context.Services.AddTransient<ISubscriberService,SubscriberService>();
        }

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder => { mvcBuilder.AddApplicationPartIfNotExists(typeof(WeixinManagementModule).Assembly); });
        }
    }
}