using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace TT.WeiXinMiddleware
{
    public class WeiXinMiddleware
    {
        private RequestDelegate Next = null;
        public IConfiguration Configuration { get; }
        public WeiXinOptions Options { get; set; }
        public WeiXinMiddleware(RequestDelegate next, IConfiguration configuration, WeiXinOptions options)
        {
            Next = next;
            Configuration = configuration;
            Options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            //if (context.Request.Path == Options.NotifyPath)
            //{
                //微信服务
                if (Options.Provider == null)
                    Options.Provider = context.RequestServices.GetService(typeof(IWeiXinProvider)) as IWeiXinProvider;
                await Options.Provider.Run(context, Configuration);
                return;
            //}
            //if (Next != null) await Next.Invoke(context);
        }
    }
}