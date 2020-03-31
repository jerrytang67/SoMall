using Volo.Abp.Settings;

namespace TT.Abp.Shops.Application
{
    public class OssManagementSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(OssManagementSettings.UploadHost),
                new SettingDefinition(OssManagementSettings.BucketName),
                new SettingDefinition(OssManagementSettings.DomainHost),
                new SettingDefinition(OssManagementSettings.AccessId),
                new SettingDefinition(OssManagementSettings.AccessKey)
            );
        }
    }

    public static class OssManagementSettings
    {
        private const string GroupName = "OssManagement";

        public const string UploadHost = GroupName + ".UploadHost";
        public const string BucketName = GroupName + ".BucketName";
        public const string DomainHost = GroupName + ".DomainHost";
        public const string AccessId = GroupName + ".AccessId";
        public const string AccessKey = GroupName + ".AccessKey";
    }
}