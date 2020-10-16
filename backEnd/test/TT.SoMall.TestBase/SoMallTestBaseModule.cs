using DotNetCore.CAP;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using NSubstitute;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace TT.SoMall
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpTestBaseModule),
        typeof(AbpAuthorizationModule),
        typeof(SoMallDomainModule)
    )]
    public class SoMallTestBaseModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => { options.IsJobExecutionEnabled = false; });

            // var hostingEnvironment = Mock.Of<IWebHostEnvironment>(e => e.ApplicationName == name);

            context.Services.AddSingleton<IWebHostEnvironment>();

            context.Services.AddSingleton<ICapPublisher, MyCapService>();

            var httpContextAccessorMock = Substitute.For<IHttpContextAccessor>();
            httpContextAccessorMock.HttpContext = new DefaultHttpContext();
            httpContextAccessorMock.HttpContext.Request.Headers.Add("AppName", new StringValues("mall_mini"));

            //context.Services.Replace(ServiceDescriptor.Transient<IHttpContextAccessor>(b => httpContextAccessor));
            //context.Services.AddSingleton<IHttpContextAccessor>(httpContextAccessor);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            SeedTestData(context);
        }

        private static void SeedTestData(ApplicationInitializationContext context)
        {
            AsyncHelper.RunSync(async () =>
            {
                using (var scope = context.ServiceProvider.CreateScope())
                {
                    await scope.ServiceProvider
                        .GetRequiredService<IDataSeeder>()
                        .SeedAsync();
                }
            });
        }
    }
}