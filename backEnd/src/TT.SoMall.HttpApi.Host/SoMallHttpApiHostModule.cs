using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using TT.SoMall.EntityFrameworkCore;
using TT.SoMall.MultiTenancy;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Conventions;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TT.SoMall
{
    [DependsOn(
        typeof(SoMallHttpApiModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
        typeof(SoMallApplicationModule),
        typeof(SoMallEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpAspNetCoreSerilogModule)
    )]
    public class SoMallHttpApiHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            ConfigureConventionalControllers(context);
            ConfigureAuthentication(context, configuration);
            ConfigureLocalization();
            ConfigureCache(configuration);
            ConfigureVirtualFileSystem(context);
            ConfigureRedis(context, configuration);
            ConfigureCors(context, configuration);
            ConfigureSwaggerServices(context);
        }

        private void ConfigureCache(IConfiguration configuration)
        {
            Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "SoMall:"; });
        }

        private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<SoMallDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}TT.SoMall.Domain.Shared"));

                    options.FileSets.ReplaceEmbeddedByPhysical<SoMallDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}TT.SoMall.Domain"));

                    options.FileSets.ReplaceEmbeddedByPhysical<SoMallApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}TT.SoMall.Application.Contracts"));

                    options.FileSets.ReplaceEmbeddedByPhysical<SoMallApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}TT.SoMall.Application"));
                });
            }
        }

        private void ConfigureConventionalControllers(ServiceConfigurationContext context)
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.MinifyGeneratedScript = true;
                options.ConventionalControllers.Create(typeof(SoMallApplicationModule).Assembly);
            });

            context.Services.AddControllers(
                opt => { opt.InputFormatters.Add(new XmlSerializerInputFormatter(opt)); }
            ).AddNewtonsoftJson(options =>
            {
                // options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                options.SerializerSettings.Converters.Add(new StringEnumConverter());

                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "SoMall";
                })
                ;
        }

        private static void ConfigureSwaggerServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "SoMall API", Version = "v1"});
                    options.DocInclusionPredicate((docName, description) => true);
                    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                });

            context.Services.AddSwaggerGenNewtonsoftSupport();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
                options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            });
        }

        private void ConfigureRedis(
            ServiceConfigurationContext context,
            IConfiguration configuration)
        {
            context.Services.AddStackExchangeRedisCache(options => { options.Configuration = configuration["Redis:ConnectionString"]; });
        }

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        //.AllowAnyOrigin()
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
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            
            
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            //app.UseVirtualFiles();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName);
            app.UseAuthentication();
            app.UseAuthorization();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseAbpRequestLocalization(option =>
            {
                option.DefaultRequestCulture = new RequestCulture("zh-Hans");
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "SoMall API"); });

            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseMvcWithDefaultRouteAndArea();
        }
    }


    internal static class ApiDescriptionConflictResolver
    {
        public static ApiDescription Resolve(IEnumerable<ApiDescription> descriptions, string httpMethod)
        {
            var parameters = descriptions
                .SelectMany(desc => desc.ParameterDescriptions)
                .GroupBy(x => x, (x, xs) => new {IsOptional = xs.Count() == 1, Parameter = x},
                    ApiParameterDescriptionEqualityComparer.Instance)
                .ToList();
            var description = descriptions.First();
            description.ParameterDescriptions.Clear();
            parameters.ForEach(x =>
            {
                if (x.Parameter.RouteInfo != null)
                    x.Parameter.RouteInfo.IsOptional = x.IsOptional;
                description.ParameterDescriptions.Add(x.Parameter);
            });
            return description;
        }
    }

    internal sealed class ApiParameterDescriptionEqualityComparer : IEqualityComparer<ApiParameterDescription>
    {
        private static readonly Lazy<ApiParameterDescriptionEqualityComparer> _instance
            = new Lazy<ApiParameterDescriptionEqualityComparer>(() =>
                new ApiParameterDescriptionEqualityComparer());

        public static ApiParameterDescriptionEqualityComparer Instance
            => _instance.Value;

        private ApiParameterDescriptionEqualityComparer()
        {
        }

        public int GetHashCode(ApiParameterDescription obj)
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + obj.ModelMetadata.GetHashCode();
                hash = hash * 23 + obj.Name.GetHashCode();
                hash = hash * 23 + obj.Source.GetHashCode();
                hash = hash * 23 + obj.Type.GetHashCode();
                return hash;
            }
        }

        public bool Equals(ApiParameterDescription x, ApiParameterDescription y)
        {
            if (!x.ModelMetadata.Equals(y.ModelMetadata)) return false;
            if (!x.Name.Equals(y.Name)) return false;
            if (!x.Source.Equals(y.Source)) return false;
            if (!x.Type.Equals(y.Type)) return false;
            return true;
        }
    }
}