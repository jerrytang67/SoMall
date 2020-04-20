using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Conventions;
using Volo.Abp.DependencyInjection;

namespace TT.SoMall
{
    [Dependency(ReplaceServices = true)]
    public class TtServiceConvention : AbpServiceConvention
    {
        public TtServiceConvention(IOptions<AbpAspNetCoreMvcOptions> options) : base(options)
        {
        }
        
        protected override string CalculateRouteTemplate(string rootPath, string controllerName, ActionModel action,
            string httpMethod,
            ConventionalControllerSetting configuration)
        {
            var controllerNameInUrl =
                NormalizeUrlControllerName(rootPath, controllerName, action, httpMethod, configuration);

            var url = $"api/{rootPath}/{controllerNameInUrl.ToCamelCase()}";

            // Add {id} path if needed
            // if (action.Parameters.Any(p => p.ParameterName == "id"))
            // {
            //     url += "/{id}";
            // }

            //Add action name if needed
            var actionNameInUrl = NormalizeUrlActionName(rootPath, controllerName, action, httpMethod, configuration);
            if (!actionNameInUrl.IsNullOrEmpty())
            {
                url += $"/{actionNameInUrl.ToCamelCase()}";

                //Add secondary Id
                var secondaryIds = action.Parameters
                    .Where(p => p.ParameterName.EndsWith("Id", StringComparison.Ordinal)).ToList();
                if (secondaryIds.Count == 1)
                {
                    url += $"/{{{secondaryIds[0].ParameterName}}}";
                }
            }

            return url;
        }


        protected override string NormalizeUrlActionName(string rootPath, string controllerName, ActionModel action,
            string httpMethod,
            ConventionalControllerSetting configuration)
        {
            var actionNameInUrl = action.ActionName
                //.RemoveHttpMethodPrefix(action.ActionName, httpMethod)
                .RemovePostFix("Async");
            if (configuration?.UrlActionNameNormalizer == null)
            {
                return actionNameInUrl;
            }

            return configuration.UrlActionNameNormalizer(
                new UrlActionNameNormalizerContext(
                    rootPath,
                    controllerName,
                    action,
                    actionNameInUrl,
                    httpMethod
                )
            );
        }
    }
}