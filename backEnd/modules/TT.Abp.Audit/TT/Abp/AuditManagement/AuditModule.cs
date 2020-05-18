using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TT.Abp.AuditManagement.Audits;
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
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<AuditManagementAutoMapperProfile>(validate: false); });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(AuditManagementModule).Assembly);
            });

            context.Services.AddAutoMapperObjectMapper<AuditManagementModule>();

            
            Configure<AuditOptions>(options =>
            {
                options.ValueProviders.Add<GlobalAuditValueProvider>();
                options.ValueProviders.Add<TenantAuditValueProvider>();
                options.ValueProviders.Add<ShopAuditValueProvider>();
            });
        }
    }

    public class AuditManagementAutoMapperProfile : Profile
    {
    }
}