using TT.Abp.AppManagement.Apps;
using TT.Abp.Mall.Localization;
using Volo.Abp.Localization;

namespace TT.Abp.Mall.Definitions
{
    public class MallAppDefinitionProvider : AppDefinitionProvider
    {
        public override void Define(IAppDefinitionContext context)
        {
            context.Add(
                new AppDefinition("mall_mini", "SoMall_App", displayName: L("mall_mini"))
            );

            context.Add(
                new AppDefinition("woju_mini", "SoMall_App", displayName: L("woju_mini"))
            );

            context.Add(
                new AppDefinition("trip_mini", "SoMall_App", displayName: L("trip_mini"))
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MallResource>(name);
        }
    }
}