using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Volo.Abp.AspNetCore.Auditing;
using Volo.Abp.DependencyInjection;

namespace TT.Abp.Core.Services
{
    public class MyAuditLogContributor : AspNetCoreAuditLogContributor, ITransientDependency
    {
        
        
        protected string GetClientIpAddress(HttpContext httpContext)
        {
            try
            {
                return GetUserIp(httpContext);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, LogLevel.Warning);
                return null;
            }
        }

        public static string GetUserIp(HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection?.RemoteIpAddress?.ToString();
            }

            return GetSingleIP(ip);
        }

        private static string GetSingleIP(string ip)
        {
            if (!string.IsNullOrEmpty(ip))
            {
                var commaIndex = ip.LastIndexOf(",", StringComparison.Ordinal);
                if (commaIndex >= 0)
                {
                    ip = ip.Substring(commaIndex + 1);
                }
            }

            return ip;
        }
    }
}