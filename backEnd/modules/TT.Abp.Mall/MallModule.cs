using Microsoft.Extensions.DependencyInjection;
using TT.Abp.AppManagement;
using TT.Abp.Mall.Application.Clients;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.EntityFrameworkCore;
using TT.Abp.Mall.Localization;
using TT.Abp.Shops;
using TT.Abp.Weixin;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.Client;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace TT.Abp.Mall
{
    [DependsOn(
        typeof(AbpHttpClientModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpHttpClientModule),
        typeof(AppManagementModule),
        typeof(WeixinModule)
    )]
    public class MallModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MallDbContext>(options => { options.AddDefaultRepositories(true); });

            context.Services.AddAutoMapperObjectMapper<MallModule>();

            Configure<AbpAutoMapperOptions>(options => { options.AddProfile<MallApplicationAutoMapperProfile>(validate: false); });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(MallModule).Assembly
                    , opts => { opts.RootPath = "mall"; });
            });

            context.Services.AddTransient<IExternalShopLookupServiceProvider, DefaultShopLookupServiceProvider>();

            //创建动态客户端代理
            context.Services.AddHttpClientProxies(typeof(WeixinModule).Assembly);

            // CAP
            //context.Services.AddTransient<ITenPayNotifyCapSubscriberService, TenPayNotifyCapSubscriberService>();


            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                // "YourRootNameSpace" is the root namespace of your project. It can be empty if your root namespace is empty.
                options.FileSets.AddEmbedded<MallModule>("TT.Abp.Mall");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                //Define a new localization resource (TestResource)
                options.Resources
                    .Add<MallResource>("zh-Hans")
                    // .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Resources/Mall");
            });

            Configure<AbpExceptionLocalizationOptions>(options => { options.MapCodeNamespace("Mall", typeof(MallResource)); });
        }
    }
}