using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Conventions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http;
using Volo.Abp.Reflection;

namespace TT.SoMall
{
    //[Dependency(ReplaceServices = true)]
    public class TtConventionalRouteBuilder : ConventionalRouteBuilder
    {
        public TtConventionalRouteBuilder(IOptions<AbpConventionalControllerOptions> options) : base(options)
        {
        }

        public override string Build(string rootPath, string controllerName, ActionModel action, string httpMethod, ConventionalControllerSetting configuration)
        {
            var controllerNameInUrl = NormalizeUrlControllerName(rootPath, controllerName, action, httpMethod, configuration);

            var url = $"api/{rootPath}/{NormalizeControllerNameCase(controllerNameInUrl, configuration)}";

            //Add {id} path if needed
            // var idParameterModel = action.Parameters.FirstOrDefault(p => p.ParameterName == "id");
            // if (idParameterModel != null)
            // {
            //     if (TypeHelper.IsPrimitiveExtended(idParameterModel.ParameterType, includeEnums: true))
            //     {
            //         url += "/{id}";
            //     }
            //     else
            //     {
            //         var properties = idParameterModel
            //             .ParameterType
            //             .GetProperties(BindingFlags.Instance | BindingFlags.Public);
            //
            //         foreach (var property in properties)
            //         {
            //             url += "/{" + NormalizeIdPropertyNameCase(property, configuration) + "}";
            //         }
            //     }
            // }

            //Add action name if needed
            var actionNameInUrl = NormalizeUrlActionName(rootPath, controllerName, action, httpMethod, configuration);
            if (!actionNameInUrl.IsNullOrEmpty())
            {
                url += $"/{NormalizeActionNameCase(actionNameInUrl, configuration)}";

                //Add secondary Id
                var secondaryIds = action.Parameters
                    .Where(p => p.ParameterName.EndsWith("Id", StringComparison.Ordinal)).ToList();
                if (secondaryIds.Count == 1)
                {
                    url += $"/{{{NormalizeSecondaryIdNameCase(secondaryIds[0], configuration)}}}";
                }
            }

            return url;
        }


        protected override string NormalizeUrlActionName(string rootPath, string controllerName, ActionModel action, string httpMethod, ConventionalControllerSetting configuration)
        {
            // return base.NormalizeUrlActionName(rootPath, controllerName, action, httpMethod, configuration);
            var actionNameInUrl = 
                //HttpMethodHelper
                //.RemoveHttpMethodPrefix(action.ActionName, httpMethod)
                action.ActionName.RemovePostFix("Async");

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
    
    
    
    
    
    //[Dependency(ReplaceServices = true)]
    public class TtServiceConvention : AbpServiceConvention
    {
        public TtServiceConvention(
            IOptions<AbpAspNetCoreMvcOptions> options,
            IConventionalRouteBuilder conventionalRouteBuilder)
            : base(options, conventionalRouteBuilder)
        {
        }

        protected override void ConfigureSelector(string rootPath, string controllerName, ActionModel action, ConventionalControllerSetting configuration)
        {
            base.ConfigureSelector(rootPath, controllerName, action, configuration);
        }


        #region Obsolete

        // protected override string CalculateRouteTemplate(string rootPath, string controllerName, ActionModel action,
        //     string httpMethod,
        //     ConventionalControllerSetting configuration)
        // {
        //     var controllerNameInUrl =
        //         NormalizeUrlControllerName(rootPath, controllerName, action, httpMethod, configuration);
        //
        //     var url = $"api/{rootPath}/{controllerNameInUrl.ToCamelCase()}";
        //
        //     // Add {id} path if needed
        //     // if (action.Parameters.Any(p => p.ParameterName == "id"))
        //     // {
        //     //     url += "/{id}";
        //     // }
        //
        //     //Add action name if needed
        //     var actionNameInUrl = NormalizeUrlActionName(rootPath, controllerName, action, httpMethod, configuration);
        //     if (!actionNameInUrl.IsNullOrEmpty())
        //     {
        //         url += $"/{actionNameInUrl.ToCamelCase()}";
        //
        //         //Add secondary Id
        //         var secondaryIds = action.Parameters
        //             .Where(p => p.ParameterName.EndsWith("Id", StringComparison.Ordinal)).ToList();
        //         if (secondaryIds.Count == 1)
        //         {
        //             url += $"/{{{secondaryIds[0].ParameterName}}}";
        //         }
        //     }
        //
        //     if (action.Parameters.Any(p => p.ParameterName == "appName"))
        //     {
        //         url += "/{appName}";
        //     }
        //
        //     return url;
        // }
        //
        //
        // protected override string NormalizeUrlActionName(string rootPath, string controllerName, ActionModel action,
        //     string httpMethod,
        //     ConventionalControllerSetting configuration)
        // {
        //     var actionNameInUrl = action.ActionName
        //         //.RemoveHttpMethodPrefix(action.ActionName, httpMethod)
        //         .RemovePostFix("Async");
        //
        //     if (configuration?.UrlActionNameNormalizer == null)
        //     {
        //         return actionNameInUrl;
        //     }
        //
        //     return configuration.UrlActionNameNormalizer(
        //         new UrlActionNameNormalizerContext(
        //             rootPath,
        //             controllerName,
        //             action,
        //             actionNameInUrl,
        //             httpMethod
        //         )
        //     );
        // }

        #endregion
    }
}