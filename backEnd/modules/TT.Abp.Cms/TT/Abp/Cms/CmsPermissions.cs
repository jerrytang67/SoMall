using TT.Abp.Cms.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Reflection;

namespace TT.Abp.Cms
{
    public class CmsPermissions
    {
        public const string GroupName = "Cms";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CmsPermissions));
        }

        public static class Categories
        {
            public const string Default = GroupName + ".Categories";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
        }
    }

    public class MallPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var accountGroup = context.AddGroup(CmsPermissions.GroupName, L("Permission:Cms"));

            var categories = accountGroup.AddPermission(CmsPermissions.Categories.Default, L("Permission:Categories"));
            categories.AddChild(CmsPermissions.Categories.Update, L("Permission:Edit"));
            categories.AddChild(CmsPermissions.Categories.Delete, L("Permission:Delete"));
            categories.AddChild(CmsPermissions.Categories.Create, L("Permission:Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CmsResource>(name);
        }
    }
}