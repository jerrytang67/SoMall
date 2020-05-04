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
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;
using TT.HttpClient.Weixin;

namespace TT.SoMall
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = services.GetConfiguration();
            
            services.AddCap(x =>
            {
                var rabbitOptions = configuration.GetSection("RabbitMQ");
                //配置数据库连接
                x.UseSqlServer(configuration.GetConnectionString("Default"));
                x.UseDashboard();

                //配置消息队列RabbitMQ
                x.UseRabbitMQ(option =>
                {
                    option.HostName = rabbitOptions["HostName"];
                    option.UserName = rabbitOptions["UserName"];
                    option.Password = rabbitOptions["Password"];
                });
            });

            services.AddSignalR();

            // services.Configure<ForwardedHeadersOptions>(options =>
            // {
            //     options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            //     options.KnownNetworks.Clear();
            //     options.KnownProxies.Clear();
            // });

            // ABP
            services.AddApplication<SoMallHttpApiHostModule>();
            // ABP End
        }

        public void Configure(IApplicationBuilder app)
        {
            IdentityModelEventSource.ShowPII = true;

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.InitializeApplication();

            app.UseCapDashboard();

            app.UseSignalR(routes =>
            {
                //routes.MapHub<ChatHub>("/chat");
                routes.MapHub<GroupChatHub>("/groupchat");
            });

            
            app.MapWhen(
                ctx =>
                    ctx.Request.Path.ToString().StartsWith("/Home/"),
                app2 =>
                {
                    app2.UseRouting();
                    app2.UseMvcWithDefaultRouteAndArea();
                }
            );
        }
    }
}