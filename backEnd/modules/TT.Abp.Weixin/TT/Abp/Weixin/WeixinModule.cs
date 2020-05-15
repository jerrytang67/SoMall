using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.Weixin.Domain;
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

            var clientCertificate = new X509Certificate2(@"C:\apiclient_cert.p12", "1486627732");
            // Path.Combine(_environment.ContentRootPath, "sts_dev_cert.pfx"), "1234");

            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(clientCertificate);

            context.Services.AddHttpClient<IPayApi, PayApi>(
                    cfg => { cfg.BaseAddress = new Uri("https://api.mch.weixin.qq.com/"); })
                .ConfigurePrimaryHttpMessageHandler(() => handler);
            ;

            context.Services.AddSingleton<ISignatureGenerator, SignatureGenerator>();

            // CAP
            //context.Services.AddTransient<WexinCapSubscriberService>();
        }
    }
}