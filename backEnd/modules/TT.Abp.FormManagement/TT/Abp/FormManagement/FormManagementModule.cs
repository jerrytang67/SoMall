using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace TT.Abp.FormManagement
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule)
    )]
    public class FormManagementModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // context.Services.AddAbpDbContext<>(options => { options.AddDefaultRepositories(); });

            context.Services.AddAutoMapperObjectMapper<FormManagementModule>();
            // AutoMapper
            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<FormApplicationAutoMapperProfile>(validate: true); });

            // AppService转APi
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(FormManagementModule).Assembly);
            });

            //创建动态客户端代理
            context.Services.AddHttpClientProxies(typeof(FormManagementModule).Assembly);
        }
    }
}