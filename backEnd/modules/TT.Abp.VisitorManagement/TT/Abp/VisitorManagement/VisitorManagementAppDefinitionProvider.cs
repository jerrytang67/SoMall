using System.Collections.Generic;
using TT.Abp.AppManagement.Apps;

namespace TT.Abp.VisitorManagement
{
    public class VisitorManagementAppDefinitionProvider : AppDefinitionProvider
    {
        public override void Define(IAppDefinitionContext context)
        {
            context.Add(
                new AppDefinition("visitor_mini", "SoMall_App", null, new Dictionary<string, string> {{"appid", "aaaa"}, {"appsec", "dsafsdf"}})
            );
        }
    }
}