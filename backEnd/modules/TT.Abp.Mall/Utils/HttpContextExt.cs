using System.Linq;

namespace TT.Abp.Mall.Utils
{
    public static class HttpContextExt
    {
        public static string GetAppName(this Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor?.HttpContext.Request.Headers["AppName"].FirstOrDefault();
        }
    }
}