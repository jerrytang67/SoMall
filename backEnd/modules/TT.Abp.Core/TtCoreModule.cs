using System.ComponentModel;
using System.Reflection;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TT.Abp.Core.Services;
using TT.Extensions.Redis;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.AutoMapper;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace TT.Abp.Core
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpAutoMapperModule)
    )]
    public class TtCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.Configure<RedisOptions>(configuration.GetSection("Redis"));
            context.Services.AddSingleton<IRedisClient, RedisClient>();

            Configure<AbpAuditingOptions>(options =>
            {
                options.Contributors.Clear();
                options.Contributors.Add(new MyAuditLogContributor());
            });

            context.Services.Replace(ServiceDescriptor.Transient<IGuidGenerator, SequentialGuid>());

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<TtCoreAutoMapperProfile>(validate: false); });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(TtCoreModule).Assembly);
            });


            context.Services.AddAutoMapperObjectMapper<TtCoreModule>();

            // JUST PUT THIS LINE TO USE MediatR Modules
            //context.Services.AddMediatR(typeof(TtCoreModule).GetTypeInfo().Assembly);
        }
    }
}