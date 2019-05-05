using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TT.WeiXinMiddleware;
using TT.WeiXinMiddleware.Extensions;

namespace TT.SoMall.WeiXinHandler
{
    public class Startup
    {

        public IServiceProvider Services { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            Services = services.BuildServiceProvider();
            //注册微信处理程序
            services.AddMediatR(typeof(Startup).Assembly);
            //services.AddWeiXinService();
            services.AddSingleton(typeof(IWeiXinProvider), typeof(SoMallWeiXinProvider));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseWeiXin(options: new WeiXinOptions()
            {
                Path = "/wx"
            });

            Services.GetService<IMediator>();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Not Fetch Any Middleware!!");
            });
        }
    }

    public class Ping : IRequest<bool>
    {
        public WeiXinContext context { get; private set; }

        public Ping(WeiXinContext context)
        {
            this.context = context;
        }
    }

    public class PingHandler : IRequestHandler<Ping, bool>
    {
        public async Task<bool> Handle(Ping request, CancellationToken cancellationToken)
        {
            var xml = new XmlSerializer(typeof(Ping));
            var bb = xml.Serialize(request);
            await request.context.HttpContext.Response.WriteAsync("ok");
            return await Task.FromResult(true);
        }
    }
}
