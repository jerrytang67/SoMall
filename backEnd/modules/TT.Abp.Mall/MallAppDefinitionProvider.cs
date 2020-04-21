using TT.Abp.AppManagement.Apps;

namespace TT.Abp.Mall
{
    public class MallAppDefinitionProvider : AppDefinitionProvider
    {
        public override void Define(IAppDefinitionContext context)
        {
            context.Add(
                new AppDefinition("mall_mini", "SoMall_App")
            );
            
            context.Add(
                new AppDefinition("woju_mini", "SoMall_App")
            );
        }
    }
}