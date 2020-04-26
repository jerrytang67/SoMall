using System;
using System.IO;
using System.Linq;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using TT.SoMall.EntityFrameworkCore;
using TT.SoMall.Localization;
using TT.SoMall.MultiTenancy;
using StackExchange.Redis;
using TT.Abp.Core;
using TT.SoMall.Menus;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Caching;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace TT.SoMall
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAccountApplicationModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(SoMallEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(TtCoreModule)

    )]
    public class SoMallIdentityServerModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<SoMallResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );

                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            });

            Configure<AbpAuditingOptions>(options =>
            {
                //options.IsEnabledForGetRequests = true;
                options.ApplicationName = "AuthServer";
            });

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<SoMallDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}TT.SoMall.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<SoMallDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}TT.SoMall.Domain"));
                });
            }

            Configure<AppUrlOptions>(options => { options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"]; });

            Configure<AbpBackgroundJobOptions>(options => { options.IsJobExecutionEnabled = false; });

            Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "SoMall:"; });

            context.Services.AddStackExchangeRedisCache(options => { options.Configuration = configuration["Redis:ConnectionString"]; });
            
            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
            
            Configure<AbpMultiTenancyOptions>(options => { options.IsEnabled = MultiTenancyConsts.IsEnabled; });

            ConfigureNavigationServices(configuration);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName);
            app.UseAuthentication();
            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseAbpRequestLocalization();
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseMvcWithDefaultRouteAndArea();
        }


        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            // 自定义GrantValidator
            context.Services.PreConfigure<IIdentityServerBuilder>(
                builder => { builder.AddExtensionGrantValidator<UserWithTenantGrantValidator>(); }
            );
        }


        private void ConfigureNavigationServices(IConfiguration configuration)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Clear();
                options.MenuContributors.Add(new SoMallMenuContributor(configuration));
            });
        }
    }
}