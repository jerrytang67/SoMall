using Microsoft.Extensions.DependencyInjection;
using TT.SoMall.WeiXinHandler;

namespace TT.WeiXinMiddleware.Extensions
{
    public static class WeiXinServiceCollectionExtension
    {
        public static void AddWeiXinService(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IWeiXinProvider), typeof(WeiXinProvide));
        }
    }
}