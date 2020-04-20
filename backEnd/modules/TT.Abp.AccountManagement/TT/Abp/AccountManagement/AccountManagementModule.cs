using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.AccountManagement.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace TT.Abp.AccountManagement
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(AbpAutoMapperModule)
    )]
    public class AccountManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AccountManagementDbContext>(options => { options.AddDefaultRepositories(true); });

            context.Services.AddAutoMapperObjectMapper<AccountManagementModule>();
            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<AccountManagementModuleApplicationAutoMapperProfile>(validate: true); });
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(AccountManagementModule).Assembly);
            });
        }
    }

    public class AccountManagementModuleApplicationAutoMapperProfile : Profile
    {
        public AccountManagementModuleApplicationAutoMapperProfile()
        {
            
        }
    }
}