using Volo.Abp.Settings;

namespace TT.Abp.Mall.Definitions
{
    public class MallSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(MallManagementSetting.PayMchId),
                new SettingDefinition(MallManagementSetting.PayKey),
                new SettingDefinition(MallManagementSetting.PayNotify),
                new SettingDefinition(MallManagementSetting.CertPath),
                new SettingDefinition(MallManagementSetting.CertPassword)
            );
        }
    }

    public static class MallManagementSetting
    {
        private const string GroupName = "MallManagement";
        public const string PayMchId = GroupName + ".PayMchId";
        public const string PayKey = GroupName + ".PayKey";
        public const string PayNotify = GroupName + ".PayNotify";
        public const string CertPath = GroupName + ".CertPath";
        public const string CertPassword = GroupName + ".CertPassword";
    }
}