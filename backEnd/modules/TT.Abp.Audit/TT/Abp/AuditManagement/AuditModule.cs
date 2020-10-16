using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.AuditManagement.Audits;
using TT.Abp.AuditManagement.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace TT.Abp.AuditManagement
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class AuditManagementModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AutoAddDefinitionProviders(context.Services);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AuditManagementDbContext>(options => { options.AddDefaultRepositories(true); });


            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<AuditManagementAutoMapperProfile>(false); });


            context.Services.AddAutoMapperObjectMapper<AuditManagementModule>();

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(AuditManagementModule).Assembly, opts => { opts.RootPath = "audit"; });
            });

            Configure<AuditOptions>(options =>
            {
                options.ValueProviders.Add<GlobalAuditValueProvider>();
                options.ValueProviders.Add<TenantAuditValueProvider>();
                options.ValueProviders.Add<OrganizationUnitAuditValueProvider>();
                options.ValueProviders.Add<ShopAuditValueProvider>();
            });
        }

        private static void AutoAddDefinitionProviders(IServiceCollection services)
        {
            var definitionProviders = new List<Type>();

            services.OnRegistred(context =>
            {
                if (typeof(IAuditDefinitionProvider).IsAssignableFrom(context.ImplementationType))
                {
                    definitionProviders.Add(context.ImplementationType);
                }
            });

            services.Configure<AuditOptions>(options => { options.DefinitionProviders.AddIfNotContains(definitionProviders); });
        }
    }
}