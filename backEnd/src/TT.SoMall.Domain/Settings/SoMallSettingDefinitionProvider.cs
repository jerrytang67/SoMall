using Volo.Abp.Settings;

namespace TT.SoMall.Settings
{
    public class SoMallSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(SoMallSettings.MySetting1));
        }
    }
}
