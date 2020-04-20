using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.AppManagement.AppManagement.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace TT.Abp.AppManagement.AppManagement
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(AbpAutoMapperModule)
    )]
    public class AppManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AppManagementDbContext>(options => { options.AddDefaultRepositories(true); });

            context.Services.AddAutoMapperObjectMapper<AppManagementModule>();
            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<AppManagementModuleApplicationAutoMapperProfile>(validate: true); });
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(AppManagementModule).Assembly);
            });
        }
    }

    public class AppManagementModuleApplicationAutoMapperProfile : Profile
    {
        public AppManagementModuleApplicationAutoMapperProfile()
        {
        }
    }
}