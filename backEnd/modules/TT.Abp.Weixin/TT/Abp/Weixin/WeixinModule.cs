using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.Core.Certificates;
using TT.Abp.Weixin.EntityFrameworkCore;
using TT.HttpClient.Weixin;
using TT.HttpClient.Weixin.Signature;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace TT.Abp.Weixin
{
    [DependsOn(
        typeof(AbpCachingModule),
        // typeof(AbpHttpClientModule),
        // typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class WeixinModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<WeixinManagementDbContext>(options => { options.AddDefaultRepositories(true); });

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

            context.Services.AddHttpClient<IPayApi, PayApi>(
                    cfg => { cfg.BaseAddress = new Uri("https://api.mch.weixin.qq.com/"); })
                .ConfigurePrimaryHttpMessageHandler(serviceProvider =>
                {
                    var certificateProvider = serviceProvider.GetService<CertificateProvider>();
                    var handler = new HttpClientHandler();
                    handler.ClientCertificates.Add(certificateProvider.GetCertificate());
                    return handler;
                });
            ;

            context.Services.AddSingleton<ISignatureGenerator, SignatureGenerator>();

            // CAP
            //context.Services.AddTransient<WexinCapSubscriberService>();
        }
    }
}