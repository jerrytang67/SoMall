using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DotNetCore.CAP;

namespace TT.SoMall
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = services.GetConfiguration();
            services.AddApplication<SoMallHttpApiHostModule>();
            
            // services.AddTransient<DotNetCore.CAP.ISubscriberService,SubscriberService>();
            services.AddDbContext<CapDbContext>();
            services.AddCap(x =>
            {
                //配置数据库连接
                x.UseEntityFramework<CapDbContext>();

                x.UseDashboard();
                //配置消息队列RabbitMQ
                x.UseRabbitMQ("localhost");
                // x.UseRabbitMQ(option =>
                // {
                //     option.HostName = configuration["RabbitMQ:Host"];
                //     // option.VirtualHost = _appConfiguration["MqSettings:MqVirtualHost"];
                //     // option.UserName = _appConfiguration["MqSettings:MqUserName"];
                //     // option.Password = _appConfiguration["MqSettings:MqPassword"];
                // });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();

            app.UseCapDashboard();
        }
    }
}