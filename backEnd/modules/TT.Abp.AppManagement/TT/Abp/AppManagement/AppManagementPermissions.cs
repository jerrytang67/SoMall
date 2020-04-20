using TT.Abp.AppManagement.AppManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Reflection;

namespace TT.Abp.AppManagement
{
    public class AppManagementPermissions
    {
        public const string GroupName = "AppManagement";

        public static class Apps
        {
            public const string Default = GroupName + ".Apps";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(AppManagementPermissions));
        }
    }

    public class MallPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var groups = context.AddGroup(AppManagementPermissions.GroupName, L("Permission:AppManagement"));

            var apps = groups.AddPermission(AppManagementPermissions.Apps.Default, L("Permission:Apps"));
            apps.AddChild(AppManagementPermissions.Apps.Update, L("Permission:Edit"));
            apps.AddChild(AppManagementPermissions.Apps.Delete, L("Permission:Delete"));
            apps.AddChild(AppManagementPermissions.Apps.Create, L("Permission:Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AppResource>(name);
        }
    }
}