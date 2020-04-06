using Volo.Abp.Settings;

namespace TT.Abp.Mall.Application
{
    public class MallSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(MallManagementSetting.AppId),
                new SettingDefinition(MallManagementSetting.AppSecret),
                new SettingDefinition(MallManagementSetting.MiniAppId),
                new SettingDefinition(MallManagementSetting.MiniAppSecret),
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
        public const string AppId = GroupName + ".AppId";
        public const string AppSecret = GroupName + ".AppSecret";
        public const string MiniAppId = GroupName + ".MiniAppId";
        public const string MiniAppSecret = GroupName + ".MiniAppSecret";
        public const string PayMchId = GroupName + ".PayMchId";
        public const string PayKey = GroupName + ".PayKey";
        public const string PayNotify = GroupName + ".PayNotify";
        public const string CertPath = GroupName + ".CertPath";
        public const string CertPassword = GroupName + ".CertPassword";
    }
}