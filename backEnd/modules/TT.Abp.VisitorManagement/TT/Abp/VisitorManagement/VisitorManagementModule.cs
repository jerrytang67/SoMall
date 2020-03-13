using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.VisitorManagement.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.VisitorManagement
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class VisitorManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<VisitorManagementDbContext>(options => { options.AddDefaultRepositories(); });
            
            context.Services.AddAutoMapperObjectMapper<VisitorManagementModule>();

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<VisitorApplicationAutoMapperProfile>(validate: true); });

            Configure<AbpAspNetCoreMvcOptions>(options => { options.ConventionalControllers.Create(typeof(VisitorManagementModule).Assembly); });

            //创建动态客户端代理
            context.Services.AddHttpClientProxies(typeof(VisitorManagementModule).Assembly);
        }
    }

    public class VisitorApplicationAutoMapperProfile : Profile
    {
        public VisitorApplicationAutoMapperProfile()
        {
        }
    }
}