using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TT.Abp.Mall.Utils
{
    public static class HttpContextExt
    {
        public static string GetAppName(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor?.HttpContext.Request.Headers["AppName"].FirstOrDefault();
        }
    }
}