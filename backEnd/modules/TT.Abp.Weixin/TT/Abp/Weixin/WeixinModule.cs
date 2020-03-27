using System;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.Weixin.Domain;
using TT.Abp.Weixin.EntityFrameworkCore;
using TT.HttpClient.Weixin;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.Weixin
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class WeixinModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<WeixinManagementDbContext>(options => { options.AddDefaultRepositories(); });
            context.Services.AddAutoMapperObjectMapper<WeixinModule>();
            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<WeixinApplicationAutoMapperProfile>(validate: true); });
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(WeixinModule).Assembly);
            });
            
            
            
            // HTTPClient
            context.Services.AddHttpClient<IWeixinApi, WeixinApi>(
                cfg => { cfg.BaseAddress = new Uri("https://api.weixin.qq.com/"); });
            
            //创建动态客户端代理
            context.Services.AddHttpClientProxies(typeof(WeixinModule).Assembly);

            // CAP
            context.Services.AddTransient<WexinCapSubscriberService>();
        }
    }
}