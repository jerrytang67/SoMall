using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace TT.WeiXinMiddleware
{
    public interface IWeiXinProvider
    {
        WeiXinOptions Options { get; set; }

        Task Run(HttpContext context, IConfiguration configuration);
    }
}