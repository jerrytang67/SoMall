using Microsoft.AspNetCore.Builder;

namespace TT.WeiXinMiddleware.Extensions
{
    public static class WeiXinMiddlewareExtensions
    {
        public static void UseWeiXin(this IApplicationBuilder app, WeiXinOptions options)
        {
            app.UseMiddleware<WeiXinMiddleware>(options);
        }
    }
}