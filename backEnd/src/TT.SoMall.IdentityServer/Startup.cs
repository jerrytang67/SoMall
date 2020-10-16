using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using TT.HttpClient.Weixin;

namespace TT.SoMall
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<SoMallIdentityServerModule>();

            // custom
            var config = services.GetConfiguration();

            services.PostConfigure<IdentityServerOptions>(options =>
            {
                // options.PublicOrigin = config["AuthServer:Authority"];
                options.IssuerUri = config["AuthServer:Authority"];
            });
            
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
            app.UseForwardedHeaders();

        }
    }
}