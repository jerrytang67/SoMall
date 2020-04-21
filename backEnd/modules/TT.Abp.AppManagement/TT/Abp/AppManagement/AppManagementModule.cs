using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.AppManagement.Apps;
using TT.Abp.AppManagement.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace TT.Abp.AppManagement
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(AbpAutoMapperModule)
    )]
    public class AppManagementModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            AutoAddDefinitionProviders(context.Services);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AppManagementDbContext>(options => { options.AddDefaultRepositories(true); });

            context.Services.AddAutoMapperObjectMapper<AppManagementModule>();
            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<AppManagementModuleAutoMapperProfile>(validate: false); });
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(AppManagementModule).Assembly);
            });


            Configure<AppOptions>(options =>
            {
                options.ValueProviders.Add<DefaultValueAppValueProvider>();
                options.ValueProviders.Add<ConfigurationAppValueProvider>();
            });
        }

        private static void AutoAddDefinitionProviders(IServiceCollection services)
        {
            var definitionProviders = new List<Type>();

            services.OnRegistred(context =>
            {
                if (typeof(IAppDefinitionProvider).IsAssignableFrom(context.ImplementationType))
                {
                    definitionProviders.Add(context.ImplementationType);
                }
            });

            services.Configure<AppOptions>(options => { options.DefinitionProviders.AddIfNotContains(definitionProviders); });
        }
    }
}