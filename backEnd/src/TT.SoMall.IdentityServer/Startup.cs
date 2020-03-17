using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Configuration;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TT.HttpClient.Weixin;

namespace TT.SoMall
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddApplication<SoMallIdentityServerModule>();

            services.PostConfigure<IdentityServerOptions>(option =>
            {
                option.PublicOrigin = "https://demo.somall.top";
                // option.IssuerUri = "https://demo.somall.top";
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }


    public class MiniGrant : IExtensionGrantValidator
    {
        public string GrantType => "mini";
        private readonly ITokenValidator _validator;

        public MiniGrant(ITokenValidator validator)
        {
            _validator = validator;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var userToken = context.Request.Raw.Get("token");

            if (string.IsNullOrEmpty(userToken))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                return;
            }

            var result = await _validator.ValidateAccessTokenAsync(userToken);
            if (result.IsError)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                return;
            }

            // get user's identity
            var sub = result.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            context.Result = new GrantValidationResult(sub, GrantType);
            await Task.CompletedTask;
        }
    }
}