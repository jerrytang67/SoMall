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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //注册微信处理程序
            services.AddSingleton(typeof(IWeiXinProvider), typeof(WeiXinProvide));
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

            app.UseWeiXin(new WeiXinOptions()
            {

            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Not Fetch Any Middleware!!");
            });
        }
    }
}
