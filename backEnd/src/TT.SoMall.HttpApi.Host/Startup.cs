using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DotNetCore.CAP;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using StackExchange.Redis;
using TT.HttpClient.Weixin;

namespace TT.SoMall
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = services.GetConfiguration();
            services.AddSingleton<IRedisClient, RedisClient>();

            services.AddApplication<SoMallHttpApiHostModule>();
            
            services.AddCap(x =>
            {
                //配置数据库连接
                x.UseSqlServer(configuration.GetConnectionString("Default"));
                x.UseDashboard();
                
                //配置消息队列RabbitMQ
                x.UseRabbitMQ("localhost");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // IdentityModelEventSource.ShowPII = true;

            app.InitializeApplication();

            app.UseCapDashboard();
        }
    }
}