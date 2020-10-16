using TT.Abp.AppManagement.Apps;

namespace TT.Abp.Cms
{
    public class CmsApp : AppDefinitionProvider
    {
        public override void Define(IAppDefinitionContext context)
        {
            context.Add(
                new AppDefinition("cms_h5", "SoMall_App")
            );
        }
    }
}